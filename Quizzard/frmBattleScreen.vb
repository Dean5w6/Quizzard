Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.IO

Public Class frmBattleScreen
    Private characterData As DataRow
    Private tmrPlayerBlock As New Timer()

    Private pixelFontCollection As New PrivateFontCollection()
    Private tempFontPath As String = String.Empty

    Private hasChronomancerUsedSkill As Boolean = False

    Private isDoubleAttackActive As Boolean = False
    Private attackPhase As Integer = 1

    Private isBlocking As Boolean = False

    Private playerMaximumHP As Integer = 100

    Private tmrQuestion As New Timer()
    Private tmrFeedback As New Timer()
    Private tmrEnemyAnimation As New Timer()
    Private tmrPlayerHit As New Timer()

    Private battleLevel As Integer
    Private ReadOnly currentPlayerId As Integer = 1
    Private playerStats As DataRow
    Private enemyStats As DataRow
    Private playerCurrentHP As Integer
    Private enemyCurrentHP As Integer
    Private questions As List(Of DataRow)
    Private currentQuestion As DataRow
    Private rnd As New Random()
    Private timeLeft As Integer
    Private isShowingFeedback As Boolean = False
    Private enemyShouldAttackNext As Boolean = False
    Private damageToApply As Integer = 0

    Private compensationQuizzite As Integer = 0
    Private compensationExp As Integer = 0
    Private selectedCharacterId As Integer
    Private enemyAnimationFrame As Integer = -1
    Private playerHitFrame As Integer = 1
    Private correctAnswerStreak As Integer = 0
    Private tookDamageThisBattle As Boolean = False

    Private blockAnimationFrame As Integer = 0

    Private tmrPlayerAttack As New Timer()
    Private tmrEnemyHit As New Timer()
    Private damageToApplyToEnemy As Integer = 0

    Private playerAttackFrame As Integer = 1
    Private enemyHitFrame As Integer = 1
    Private idleEnemyBackground As Image

    Public Sub New()
        InitializeComponent()
        AddHandler tmrQuestion.Tick, AddressOf tmrQuestion_Tick
        AddHandler tmrFeedback.Tick, AddressOf tmrFeedback_Tick
        AddHandler tmrEnemyAnimation.Tick, AddressOf tmrEnemyAnimation_Tick
        AddHandler tmrPlayerHit.Tick, AddressOf tmrPlayerHit_Tick
        AddHandler tmrPlayerBlock.Tick, AddressOf tmrPlayerBlock_Tick

        AddHandler tmrPlayerAttack.Tick, AddressOf tmrPlayerAttack_Tick
        AddHandler tmrEnemyHit.Tick, AddressOf tmrEnemyHit_Tick
    End Sub

    Public Sub New(ByVal level As Integer)
        Me.New()
        Me.battleLevel = level
        AddHandler tmrPlayerBlock.Tick, AddressOf tmrPlayerBlock_Tick
    End Sub

    Private Sub frmBattleScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFont()
        ApplyCustomFont()
        StartBattle()
        picEnemySprite.Parent = picPlayerSprite
        picEnemySprite.Location = New Point(-38, 29)
    End Sub

    Private Sub StartBattle()
        playerStats = DatabaseManager.GetPlayerProgress(currentPlayerId)
        enemyStats = DatabaseManager.GetEnemyForLevel(battleLevel)
        If playerStats Is Nothing OrElse enemyStats Is Nothing Then
            Me.Close() : Return
        End If

        selectedCharacterId = CInt(playerStats("SelectedCharacterID"))
        characterData = DatabaseManager.GetCharacterData(selectedCharacterId)
        If characterData Is Nothing Then
            MessageBox.Show("Could not load selected character data!", "Error")
            Me.Close() : Return
        End If

        Dim selectedDeckId As Integer = CInt(playerStats("SelectedDeckID"))
        Dim questionTable As DataTable = DatabaseManager.GetQuestionsForDeck(selectedDeckId)
        If questionTable Is Nothing OrElse questionTable.Rows.Count = 0 Then
            MessageBox.Show("The selected deck has no questions!", "Error")
            Me.Close() : Return
        End If
        questions = questionTable.AsEnumerable().ToList().OrderBy(Function(x) rnd.Next()).ToList()

        tookDamageThisBattle = False
        correctAnswerStreak = 0
        hasChronomancerUsedSkill = False
        compensationExp = 0
        compensationQuizzite = 0

        InitializeUI()
        AskNextQuestion()
    End Sub

    Private Sub InitializeUI()
        Dim idleSpriteName As String = $"char{selectedCharacterId}Idle"
        idleEnemyBackground = My.Resources.s1

        selectedCharacterId = CInt(playerStats("SelectedCharacterID"))
        Try
            picPlayerSprite.Image = CType(My.Resources.ResourceManager.GetObject(idleSpriteName), Image)
        Catch ex As Exception
            picPlayerSprite.Image = Nothing
        End Try

        playerCurrentHP = 100

        lblPlayerName.Text = characterData("CharacterName").ToString()
        pbPlayerHP.Maximum = playerCurrentHP
        pbPlayerHP.Value = playerCurrentHP
        lblPlayerHP.Text = $"HP: {playerCurrentHP} / {pbPlayerHP.Maximum}"

        enemyCurrentHP = CInt(enemyStats("BaseHP"))
        lblEnemyName.Text = enemyStats("EnemyName").ToString()
        pbEnemyHP.Maximum = enemyCurrentHP
        pbEnemyHP.Value = enemyCurrentHP
        lblEnemyHP.Text = $"HP: {enemyCurrentHP} / {pbEnemyHP.Maximum}"
        pbEnemyHP.ForeColor = Color.Red

        Dim savedProgress As DataRow = DatabaseManager.GetStageProgress(currentPlayerId, battleLevel)

        If savedProgress IsNot Nothing Then
            playerCurrentHP = CInt(savedProgress("PlayerCurrentHP"))
            enemyCurrentHP = CInt(savedProgress("EnemyCurrentHP"))
            compensationExp = CInt(savedProgress("CompensationEXP"))
            compensationQuizzite = CInt(savedProgress("CompensationQuizzite"))
            MessageBox.Show("Battle resumed.", "Progress Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            playerCurrentHP = 100
            enemyCurrentHP = CInt(enemyStats("BaseHP"))
            compensationExp = 0
            compensationQuizzite = 0
        End If

        pbPlayerHP.Maximum = 100
        pbPlayerHP.Value = playerCurrentHP
        lblPlayerHP.Text = $"HP: {playerCurrentHP} / {pbPlayerHP.Maximum}"

        pbEnemyHP.Maximum = CInt(enemyStats("BaseHP"))
        pbEnemyHP.Value = enemyCurrentHP
        lblEnemyHP.Text = $"HP: {enemyCurrentHP} / {pbEnemyHP.Maximum}"
        pbEnemyHP.ForeColor = Color.Red
    End Sub

    Private Sub AskNextQuestion()
        enemyAnimationFrame = -1

        If isShowingFeedback Then Return

        If questions.Count = 0 Then
            MessageBox.Show("You've answered all questions in this deck! The battle is paused.", "Deck Complete!")

            DatabaseManager.SaveStageProgress(currentPlayerId, battleLevel, playerCurrentHP, enemyCurrentHP, compensationExp, compensationQuizzite)

            btnBackToLobby_Click(Nothing, Nothing)
            Return
        End If

        currentQuestion = questions(0)
        questions.RemoveAt(0)

        timeLeft = 30 + (CInt(playerStats("Stat_Focus")) / 2)
        If CInt(characterData("CharacterID")) = 3 AndAlso Not hasChronomancerUsedSkill Then
            timeLeft += 10
            hasChronomancerUsedSkill = True
        End If

        Dim questionDisplay As String = currentQuestion("QuestionText").ToString()
        If CInt(characterData("CharacterID")) = 2 Then
            If rnd.Next(1, 101) <= 30 Then
                Dim correctAnswer As String = currentQuestion("Answer").ToString()
                If correctAnswer.Length >= 2 Then
                    questionDisplay &= vbCrLf & $"Hint: The answer starts with '{correctAnswer.Substring(0, 2)}'..."
                End If
            End If
        End If

        lblQuestionText.Text = questionDisplay
        lblQuestionText.ForeColor = Color.White
        txtPlayerAnswer.Clear()
        txtPlayerAnswer.Enabled = True
        btnSubmitAnswer.Enabled = True
        txtPlayerAnswer.Focus()
        lblTimer.Text = timeLeft.ToString()
        tmrQuestion.Interval = 1000
        tmrQuestion.Start()
    End Sub

    Private Sub btnSubmitAnswer_Click(sender As Object, e As EventArgs) Handles btnSubmitAnswer.Click
        tmrQuestion.Stop()
        txtPlayerAnswer.Enabled = False
        btnSubmitAnswer.Enabled = False

        Dim correctAnswer As String = currentQuestion("Answer").ToString()
        Dim playerAnswer As String = txtPlayerAnswer.Text.Trim()

        If String.Equals(playerAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase) Then
            correctAnswerStreak += 1
            compensationExp += 2
            compensationQuizzite += 2
            DatabaseManager.UpdateQuestProgress(currentPlayerId, "CORRECT_ANSWER")
            DatabaseManager.UpdateQuestProgress(currentPlayerId, "CORRECT_STREAK", correctAnswerStreak)

            damageToApplyToEnemy = 5 + CInt(playerStats("Stat_Intelligence"))

            isDoubleAttackActive = (CInt(characterData("CharacterID")) = 4 AndAlso rnd.Next(1, 101) <= 50)

            ShowFeedback("Correct!", False)
        Else
            correctAnswerStreak = 0
            ShowFeedback($"Incorrect! The answer was: {correctAnswer}", True)
        End If
    End Sub

    Private Sub ShowFeedback(message As String, Optional enemyAttacks As Boolean = False)
        isShowingFeedback = True
        enemyShouldAttackNext = enemyAttacks
        lblQuestionText.Text = message
        lblQuestionText.ForeColor = If(enemyAttacks, Color.Red, Color.LightGreen)
        tmrFeedback.Interval = 2000
        tmrFeedback.Start()
    End Sub

    Private Sub EnemyTurn()
        If CInt(characterData("CharacterID")) = 5 AndAlso rnd.Next(1, 101) <= 30 Then
            isBlocking = True
            tmrEnemyAnimation.Interval = 150
            tmrEnemyAnimation.Start()
            Return
        End If

        tookDamageThisBattle = True
        Dim damageTaken As Integer = CInt(enemyStats("BaseAttack")) - CInt(playerStats("Stat_Resilience"))
        damageToApply = Math.Max(1, damageTaken)
        enemyAnimationFrame = 1
        picEnemySprite.Visible = True
        tmrEnemyAnimation.Interval = 150
        tmrEnemyAnimation.Start()
    End Sub

    Private Sub tmrEnemyAnimation_Tick(sender As Object, e As EventArgs)
        If Not isBlocking Then
            Select Case enemyAnimationFrame
                Case 0, 1
                    Me.BackgroundImage = My.Resources.s1a
                    picEnemySprite.Image = Nothing
                Case 2 : picEnemySprite.Image = My.Resources.s1a1
                Case 3 : picEnemySprite.Image = My.Resources.s1a2
                Case 4 : picEnemySprite.Image = My.Resources.s1a3
                Case 5 : picEnemySprite.Image = My.Resources.s1a4
                Case 6 : picEnemySprite.Image = My.Resources.s1a5
                Case 7 : picEnemySprite.Image = Nothing
                Case 8
                    tmrEnemyAnimation.Stop()
                    picEnemySprite.Visible = False
                    Me.BackgroundImage = My.Resources.s1
                    playerCurrentHP -= damageToApply
                    pbPlayerHP.Value = Math.Max(0, playerCurrentHP)
                    lblPlayerHP.Text = $"HP: {pbPlayerHP.Value} / {pbPlayerHP.Maximum}"
                    damageToApply = 0
                    If playerCurrentHP <= 0 Then
                        Defeat()
                    Else
                        StartPlayerHitAnimation()
                    End If
            End Select
        Else
            Select Case enemyAnimationFrame
                Case 0 : Me.BackgroundImage = My.Resources.s1a
                Case 1
                    Me.BackgroundImage = My.Resources.s1a
                    picPlayerSprite.Image = My.Resources.char5s1
                Case 2, 3, 4
                    picPlayerSprite.Image = My.Resources.char5s1
                Case 5, 6, 7, 8, 9, 10
                    picPlayerSprite.Image = My.Resources.char5s2
                Case 11
                    Me.BackgroundImage = My.Resources.s1
                    picPlayerSprite.Image = My.Resources.char5Idle
                Case 12
                    tmrEnemyAnimation.Stop()
                    picEnemySprite.Visible = False
                    isBlocking = False
                    AskNextQuestion()
            End Select
        End If
        enemyAnimationFrame += 1
    End Sub

    Private Sub StartPlayerHitAnimation()
        playerHitFrame = 1
        tmrPlayerHit.Interval = 100
        tmrPlayerHit.Start()
    End Sub

    Private Sub tmrPlayerHit_Tick(sender As Object, e As EventArgs)
        Try
            Select Case playerHitFrame
                Case 1, 4, 7
                    Select Case selectedCharacterId
                        Case 1 : picPlayerSprite.Image = My.Resources.char1wh
                        Case 2 : picPlayerSprite.Image = My.Resources.char2wh
                        Case 3 : picPlayerSprite.Image = My.Resources.char3wh
                        Case 4 : picPlayerSprite.Image = My.Resources.char4wh
                        Case 5 : picPlayerSprite.Image = My.Resources.char5wh
                        Case 6 : picPlayerSprite.Image = My.Resources.char6wh
                    End Select

                Case 2, 5
                    picPlayerSprite.Image = Nothing

                Case 3, 6, 8
                    Select Case selectedCharacterId
                        Case 1 : picPlayerSprite.Image = My.Resources.char1Idle
                        Case 2 : picPlayerSprite.Image = My.Resources.char2Idle
                        Case 3 : picPlayerSprite.Image = My.Resources.char3Idle
                        Case 4 : picPlayerSprite.Image = My.Resources.char4Idle
                        Case 5 : picPlayerSprite.Image = My.Resources.char5Idle
                        Case 6 : picPlayerSprite.Image = My.Resources.char6Idle
                    End Select

                Case Else
                    tmrPlayerHit.Stop()
                    playerHitFrame = 0
                    AskNextQuestion()
            End Select

        Catch ex As Exception
            tmrPlayerHit.Stop()
            playerHitFrame = 0
            AskNextQuestion()
        End Try

        playerHitFrame += 1
    End Sub

    Private Sub tmrQuestion_Tick(sender As Object, e As EventArgs)
        timeLeft -= 1
        lblTimer.Text = timeLeft.ToString()
        If timeLeft <= 0 Then
            tmrQuestion.Stop()
            txtPlayerAnswer.Enabled = False
            btnSubmitAnswer.Enabled = False
            ShowFeedback("Time's up!", True)
        End If
    End Sub

    Private Sub tmrFeedback_Tick(sender As Object, e As EventArgs)
        tmrFeedback.Stop()
        isShowingFeedback = False
        If enemyShouldAttackNext Then
            EnemyTurn()
        Else
            StartPlayerAttackAnimation()
        End If
    End Sub

    Private Sub Victory()
        Dim baseExp As Integer = 100
        Dim baseQuizzite As Integer = 60
        Dim expGained As Integer = CInt(baseExp * (1 + 0.1 * (battleLevel - 1)))

        Dim baseQuizziteDrop As Integer = 25
        Dim bonusQuizzite As Integer = CInt(playerStats("Stat_Luck"))
        Dim totalQuizziteGained As Integer = CInt(baseQuizzite * (1 + 0.2 * (battleLevel - 1)))
        totalQuizziteGained += CInt(playerStats("Stat_Luck"))

        MessageBox.Show($"VICTORY!{vbCrLf}{vbCrLf}You earned {expGained} EXP and {totalQuizziteGained} Quizzite!", "Battle Over", MessageBoxButtons.OK, MessageBoxIcon.Information)

        DatabaseManager.AddPlayerQuizzite(currentPlayerId, totalQuizziteGained)
        DatabaseManager.ClearStageProgress(currentPlayerId, battleLevel)
        If Not tookDamageThisBattle Then
            DatabaseManager.UpdateQuestProgress(currentPlayerId, "FLAWLESS_VICTORY")
        End If
        DatabaseManager.AwardExpAndCheckLevelUp(currentPlayerId, expGained)

        DatabaseManager.ClearStageProgress(currentPlayerId, battleLevel)
        DatabaseManager.AdvancePlayerLevel(currentPlayerId)

        btnBackToLobby_Click(Nothing, Nothing)
    End Sub

    Private Sub Defeat()
        If compensationExp > 50 Then compensationExp = 50
        If compensationQuizzite > 30 Then compensationQuizzite = 30

        Dim message As String = "DEFEATED..."
        If compensationExp > 0 Then
            DatabaseManager.AwardPlayerExp(currentPlayerId, compensationExp)
            message &= $"{vbCrLf}{vbCrLf}You recovered {compensationExp} EXP."
        End If
        If compensationQuizzite > 0 Then
            DatabaseManager.AddPlayerQuizzite(currentPlayerId, compensationQuizzite)
            message &= $"{vbCrLf}You scavenged {compensationQuizzite} Quizzite."
        End If

        MessageBox.Show(message, "Battle Over")
        DatabaseManager.ClearStageProgress(currentPlayerId, battleLevel)
        btnBackToLobby_Click(Nothing, Nothing)
    End Sub

    Private Sub btnBackToLobby_Click(sender As Object, e As EventArgs)
        tmrQuestion.Stop()
        tmrFeedback.Stop()
        tmrEnemyAnimation.Stop()
        tmrPlayerHit.Stop()
        Dim lobby = Application.OpenForms.OfType(Of frmLobby).FirstOrDefault()
        If lobby IsNot Nothing Then
            lobby.Show()
            lobby.LoadLobbyData()
        Else
            Dim newLobby As New frmLobby()
            newLobby.Show()
        End If
        Me.Close()
    End Sub

    Private Sub InitializeFont()
        Try
            tempFontPath = Path.ChangeExtension(Path.GetTempFileName(), ".ttf")
            File.WriteAllBytes(tempFontPath, My.Resources.PressStart2P_Regular)
            pixelFontCollection.AddFontFile(tempFontPath)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ApplyCustomFont()
        If pixelFontCollection.Families.Length = 0 Then Return
        lblPlayerName.Font = New Font(pixelFontCollection.Families(0), 9)
        lblPlayerHP.Font = New Font(pixelFontCollection.Families(0), 7)
        lblEnemyName.Font = New Font(pixelFontCollection.Families(0), 9)
        lblEnemyHP.Font = New Font(pixelFontCollection.Families(0), 7)
        lblQuestionText.Font = New Font(pixelFontCollection.Families(0), 11)
        txtPlayerAnswer.Font = New Font(pixelFontCollection.Families(0), 9)
        btnSubmitAnswer.Font = New Font(pixelFontCollection.Families(0), 9)
        lblTimer.Font = New Font(pixelFontCollection.Families(0), 16)
    End Sub

    Private Sub frmBattleScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Not String.IsNullOrEmpty(tempFontPath) AndAlso File.Exists(tempFontPath) Then
                File.Delete(tempFontPath)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub StartPlayerBlockAnimation()
        blockAnimationFrame = 1
        tmrPlayerBlock.Interval = 150
        tmrPlayerBlock.Start()
    End Sub


    Private Sub tmrPlayerBlock_Tick(sender As Object, e As EventArgs)
        Try
            Select Case blockAnimationFrame
                Case 1, 2, 3, 4
                    picPlayerSprite.Image = My.Resources.char5s1
                Case 5, 6, 7, 8
                    picPlayerSprite.Image = My.Resources.char5s2
                Case 9
                    picPlayerSprite.Image = My.Resources.char5Idle
                Case Else
                    tmrPlayerBlock.Stop()
                    tmrFeedback.Interval = 1
                    tmrFeedback.Start()
                    Return
            End Select
        Catch ex As Exception
            tmrPlayerBlock.Stop()
            tmrFeedback.Interval = 1
            tmrFeedback.Start()
        End Try

        blockAnimationFrame += 1
    End Sub

    Private Sub StartPlayerAttackAnimation()
        Try
            Select Case selectedCharacterId
                Case 1 : picPlayerSprite.Image = My.Resources.char1a
                Case 2 : picPlayerSprite.Image = My.Resources.char2a
                Case 3 : picPlayerSprite.Image = My.Resources.char3a
                Case 4 : picPlayerSprite.Image = My.Resources.char4a
                Case 5 : picPlayerSprite.Image = My.Resources.char5a
                Case 6 : picPlayerSprite.Image = My.Resources.char6a
            End Select
        Catch ex As Exception
            picPlayerSprite.Image = CType(My.Resources.ResourceManager.GetObject($"char{selectedCharacterId}Idle"), Image)
        End Try

        playerAttackFrame = 1
        picPlayerAttack.Visible = True
        tmrPlayerAttack.Interval = 150
        If isDoubleAttackActive Then
            tmrPlayerAttack.Interval = 100
        End If

        If selectedCharacterId = 6 Then
            tmrPlayerAttack.Interval = 205
        End If
        tmrPlayerAttack.Start()
    End Sub

    Private Sub tmrPlayerAttack_Tick(sender As Object, e As EventArgs)
        Try
            Select Case selectedCharacterId
                Case 1 ' Noob Wizard (5 frames)
                    Select Case playerAttackFrame
                        Case 1 : picPlayerAttack.Image = My.Resources.char1a1
                        Case 2 : picPlayerAttack.Image = My.Resources.char1a2
                        Case 3 : picPlayerAttack.Image = My.Resources.char1a3
                        Case 4 : picPlayerAttack.Image = My.Resources.char1a4
                        Case 5 : picPlayerAttack.Image = My.Resources.char1a5
                        Case Else : EndPlayerAttackSequence()
                    End Select

                Case 2 ' Hexa (6 frames)
                    Select Case playerAttackFrame
                        Case 1 : picPlayerAttack.Image = My.Resources.char2a1
                        Case 2 : picPlayerAttack.Image = My.Resources.char2a2
                        Case 3 : picPlayerAttack.Image = My.Resources.char2a3
                        Case 4 : picPlayerAttack.Image = My.Resources.char2a4
                        Case 5 : picPlayerAttack.Image = My.Resources.char2a5
                        Case 6 : picPlayerAttack.Image = My.Resources.char2a6
                        Case Else : EndPlayerAttackSequence()
                    End Select

                Case 3 ' Chronomancer (5 frames)
                    Select Case playerAttackFrame
                        Case 1 : picPlayerAttack.Image = My.Resources.char3a1
                        Case 2 : picPlayerAttack.Image = My.Resources.char3a2
                        Case 3 : picPlayerAttack.Image = My.Resources.char3a3
                        Case 4 : picPlayerAttack.Image = My.Resources.char3a4
                        Case 5 : picPlayerAttack.Image = My.Resources.char3a5
                        Case Else : EndPlayerAttackSequence()
                    End Select

                Case 4 ' Sage Blaster (10 frames, 2 phases)
                    If attackPhase = 1 Then
                        Select Case playerAttackFrame
                            Case 1 : picPlayerAttack.Image = My.Resources.char4a1
                            Case 2 : picPlayerAttack.Image = My.Resources.char4a2
                            Case 3 : picPlayerAttack.Image = My.Resources.char4a3
                            Case 4 : picPlayerAttack.Image = My.Resources.char4a4
                            Case 5 : picPlayerAttack.Image = My.Resources.char4a5
                            Case 6
                                ' End of phase 1
                                If Not isDoubleAttackActive Then
                                    picPlayerSprite.Image = My.Resources.char4Idle
                                End If
                                picPlayerAttack.Image = Nothing

                                tmrPlayerAttack.Stop()
                                ApplyDamageAndTriggerEnemyHit()
                        End Select
                    Else
                        Select Case playerAttackFrame
                            Case 1 : picPlayerAttack.Image = My.Resources.char4a6
                            Case 2 : picPlayerAttack.Image = My.Resources.char4a7
                            Case 3 : picPlayerAttack.Image = My.Resources.char4a8
                            Case 4 : picPlayerAttack.Image = My.Resources.char4a9
                            Case 5 : picPlayerAttack.Image = My.Resources.char4a10
                            Case 6
                                EndPlayerAttackSequence()
                        End Select
                    End If

                Case 5 ' Shield Mage (5 frames)
                    Select Case playerAttackFrame
                        Case 1 : picPlayerAttack.Image = My.Resources.char5a1
                        Case 2 : picPlayerAttack.Image = My.Resources.char5a2
                        Case 3 : picPlayerAttack.Image = My.Resources.char5a3
                        Case 4 : picPlayerAttack.Image = My.Resources.char5a4
                        Case 5 : picPlayerAttack.Image = My.Resources.char5a5
                        Case Else : EndPlayerAttackSequence()
                    End Select

                Case 6 ' Mana Thief (6 frames)
                    Select Case playerAttackFrame
                        Case 1 : picPlayerAttack.Image = My.Resources.char6a1
                        Case 2 : picPlayerAttack.Image = My.Resources.char6a2
                        Case 3 : picPlayerAttack.Image = My.Resources.char6a3
                        Case 4 : picPlayerAttack.Image = My.Resources.char6a4
                        Case 5 : picPlayerAttack.Image = My.Resources.char6a5
                        Case 6 : picPlayerAttack.Image = My.Resources.char6a6
                        Case 7
                            EndPlayerAttackSequence()
                            pbPlayerHP.Value = playerCurrentHP
                            playerCurrentHP += 2
                            lblPlayerHP.Text = $"HP: {playerCurrentHP} / {pbPlayerHP.Maximum}"
                            If playerCurrentHP > playerMaximumHP Then
                                playerCurrentHP = playerMaximumHP
                            End If
                    End Select
            End Select

        Catch ex As Exception
            EndPlayerAttackSequence()
        End Try
        playerAttackFrame += 1
    End Sub

    Private Sub StartEnemyHitAnimation()
        enemyHitFrame = 1
        tmrEnemyHit.Interval = 100
        tmrEnemyHit.Start()
    End Sub

    Private Function GetMaxAttackFrames(charId As Integer) As Integer
        Select Case charId
            Case 2, 6 ' Hexa, Mana Thief
                Return 6
            Case 4 ' Sage Blaster
                Return 10
            Case Else ' Noob Wizard, Chronomancer, Shield Mage
                Return 5
        End Select
    End Function

    Private Sub ApplyDamageAndTriggerEnemyHit()
        ' --- SKILL IMPLEMENTATION: Mana Thief (ID 6) ---
        If CInt(characterData("CharacterID")) = 6 Then
            Dim hpStolen As Integer = CInt(damageToApplyToEnemy * 0.5) ' 50% of damage dealt
            playerCurrentHP = Math.Min(pbPlayerHP.Maximum, playerCurrentHP + hpStolen)
            ' No need to show a message here, the visual effect is the reward
        End If

        ' Apply damage to the enemy and update UI
        enemyCurrentHP -= damageToApplyToEnemy
        pbEnemyHP.Value = Math.Max(0, enemyCurrentHP)
        lblEnemyHP.Text = $"HP: {pbEnemyHP.Value} / {pbEnemyHP.Maximum}"

        If enemyCurrentHP <= 0 Then
            Victory() ' Enemy defeated, skip hit animation
        Else
            StartEnemyHitAnimation() ' Trigger the enemy's hit animation
        End If
    End Sub

    Private Sub EndPlayerAttackSequence()
        tmrPlayerAttack.Stop()
        picPlayerAttack.Image = Nothing

        ' Restore player idle sprite
        picPlayerSprite.Image = CType(My.Resources.ResourceManager.GetObject($"char{selectedCharacterId}Idle"), Image)

        ' Apply damage for the final (or only) hit
        ApplyDamageAndTriggerEnemyHit()

        ' Reset flags for the next turn
        isDoubleAttackActive = False
        attackPhase = 1
    End Sub

    Private Sub tmrEnemyHit_Tick(sender As Object, e As EventArgs)
        Select Case enemyHitFrame
            Case 1, 4, 7 : Me.BackgroundImage = My.Resources.s1h ' Whited version
            Case 2, 5 : Me.BackgroundImage = My.Resources.s1b ' Blank version
            Case 3, 6 : Me.BackgroundImage = My.Resources.s1 ' Regular version
            Case 8 : Me.BackgroundImage = idleEnemyBackground  ' Final restore
            Case Else
                ' --- ENEMY HIT ANIMATION FINISHED ---
                tmrEnemyHit.Stop()

                ' Check if this was the first hit of a double attack
                If isDoubleAttackActive AndAlso attackPhase = 1 Then
                    attackPhase = 2 ' Move to the second phase
                    playerAttackFrame = 1 ' Reset frame counter for the second animation
                    tmrPlayerAttack.Start() ' Restart the player attack timer
                Else
                    ' Otherwise, the turn is over
                    AskNextQuestion()
                End If
        End Select
        enemyHitFrame += 1
    End Sub
End Class