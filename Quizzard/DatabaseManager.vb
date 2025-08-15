Imports Microsoft.Data.SqlClient
Imports System.Data

Public Module DatabaseManager
    Private ReadOnly connectionString As String = "Server=YOUR_SERVER_INSTANCE;Database=QuizzardDB;Integrated Security=True;TrustServerCertificate=True;"

    Public Function GetAllDecks() As DataTable
        Dim decksTable As New DataTable()

        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT DeckID, DeckName, Category FROM Decks ORDER BY DeckName;"

                Using adapter As New SqlDataAdapter(query, connection)
                    adapter.Fill(decksTable)
                End Using

            Catch ex As Exception
                MessageBox.Show("Failed to load decks from the database." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return decksTable
    End Function

    Public Function GetDataTable(ByVal query As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As New SqlConnection(connectionString)
                Using adapter As New SqlDataAdapter(query, conn)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("A database error occurred: " & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    Public Function ExecuteNonQuery(ByVal query As String) As Boolean
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("A database error occurred: " & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function GetPlayerProgress(ByVal playerId As Integer) As DataRow
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Try
                Dim query As String = "SELECT * FROM Players WHERE PlayerID = @PlayerID"
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@PlayerID", playerId)
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Database Error in GetPlayerProgress: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function GetEnemyForLevel(ByVal level As Integer) As DataRow
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Try
                Dim query As String = "SELECT * FROM Enemies WHERE EnemyID = @Level"
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Level", level)
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0)
                Else
                    Return Nothing ' No enemy defined for this level yet
                End If
            Catch ex As Exception
                MessageBox.Show("Database Error in GetEnemyForLevel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ResetAnsweredQuestionsForDeck(ByVal playerId As Integer, ByVal deckId As Integer) As Boolean
        Using conn As New SqlConnection(connectionString)
            Try
                Dim query As String = "DELETE FROM PlayerAnsweredQuestions WHERE PlayerID = @PlayerID AND QuestionID IN (SELECT QuestionID FROM Questions WHERE DeckID = @DeckID)"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PlayerID", playerId)
                cmd.Parameters.AddWithValue("@DeckID", deckId)

                conn.Open()
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MessageBox.Show("Database Error in ResetAnsweredQuestionsForDeck: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function DeleteDeck(deckId As Integer) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "DELETE FROM Decks WHERE DeckID = @DeckID;"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@DeckID", deckId)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    Return rowsAffected > 0
                End Using

            Catch ex As Exception
                MessageBox.Show("Failed to delete the deck." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function AddQuestion(deckId As Integer, questionText As String, answer As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "INSERT INTO Questions (DeckID, QuestionText, Answer) VALUES (@DeckID, @QuestionText, @Answer);"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@DeckID", deckId)
                    command.Parameters.AddWithValue("@QuestionText", questionText)
                    command.Parameters.AddWithValue("@Answer", answer)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    Return rowsAffected > 0
                End Using

            Catch ex As Exception
                MessageBox.Show("Failed to add the new question." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function DeleteQuestion(questionId As Integer) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "DELETE FROM Questions WHERE QuestionID = @QuestionID;"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@QuestionID", questionId)
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to delete the question." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function UpdateQuestion(questionId As Integer, newQuestionText As String, newAnswer As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "UPDATE Questions SET QuestionText = @QuestionText, Answer = @Answer WHERE QuestionID = @QuestionID;"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@QuestionID", questionId)
                    command.Parameters.AddWithValue("@QuestionText", newQuestionText)
                    command.Parameters.AddWithValue("@Answer", newAnswer)
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to update the question." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function AddDeck(deckName As String, category As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "INSERT INTO Decks (DeckName, Category) VALUES (@DeckName, @Category);"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@DeckName", deckName)
                    command.Parameters.AddWithValue("@Category", category)
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            Catch ex As Exception
                MessageBox.Show("Failed to create the new deck." & vbCrLf & "Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function UpgradePlayerStat(ByVal playerId As Integer, ByVal statNameToUpgrade As String) As Boolean
        Dim validStats As New List(Of String) From {"Stat_Intelligence", "Stat_Focus", "Stat_Resilience", "Stat_Luck"}
        If Not validStats.Contains(statNameToUpgrade) Then
            MessageBox.Show("Invalid stat name provided.", "Error")
            Return False
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                ' First, check if the player has skill points.
                Dim checkCmd As New SqlCommand("SELECT UnspentSkillPoints FROM Players WHERE PlayerID = @PlayerID", conn, transaction)
                checkCmd.Parameters.AddWithValue("@PlayerID", playerId)
                Dim points As Integer = CInt(checkCmd.ExecuteScalar())

                If points > 0 Then
                    Dim updateQuery As String = String.Format("UPDATE Players SET {0} = {0} + 1, UnspentSkillPoints = UnspentSkillPoints - 1 WHERE PlayerID = @PlayerID", statNameToUpgrade)
                    Dim updateCmd As New SqlCommand(updateQuery, conn, transaction)
                    updateCmd.Parameters.AddWithValue("@PlayerID", playerId)
                    updateCmd.ExecuteNonQuery()

                    transaction.Commit()
                    Return True
                Else
                    transaction.Rollback()
                    Return False
                End If
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Database Error in UpgradePlayerStat: " & ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Sub AwardExpAndCheckLevelUp(ByVal playerId As Integer, ByVal expGained As Integer)
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE Players SET CurrentEXP = CurrentEXP + @exp WHERE PlayerID = @PlayerID", conn)
            cmd.Parameters.AddWithValue("@exp", expGained)
            cmd.Parameters.AddWithValue("@PlayerID", playerId)
            cmd.ExecuteNonQuery()

            Dim needsLevelUpCheck As Boolean = True
            While needsLevelUpCheck
                Dim dt As New DataTable()
                Dim adapter As New SqlDataAdapter("SELECT PlayerLevel, CurrentEXP, EXPToNextLevel FROM Players WHERE PlayerID = @PlayerID", conn)
                adapter.SelectCommand.Parameters.AddWithValue("@PlayerID", playerId)
                adapter.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Dim row = dt.Rows(0)
                    Dim currentExp = CInt(row("CurrentEXP"))
                    Dim expToNext = CInt(row("EXPToNextLevel"))

                    If currentExp >= expToNext Then
                        Dim newLevel = CInt(row("PlayerLevel")) + 1
                        Dim remainingExp = currentExp - expToNext
                        Dim newExpToNext = CInt(expToNext * 1.5)

                        Dim levelUpCmd As New SqlCommand("UPDATE Players SET PlayerLevel = @Lvl, CurrentEXP = @Exp, EXPToNextLevel = @ExpNext, UnspentSkillPoints = UnspentSkillPoints + 1 WHERE PlayerID = @PlayerID", conn)
                        levelUpCmd.Parameters.AddWithValue("@Lvl", newLevel)
                        levelUpCmd.Parameters.AddWithValue("@Exp", remainingExp)
                        levelUpCmd.Parameters.AddWithValue("@ExpNext", newExpToNext)
                        levelUpCmd.Parameters.AddWithValue("@PlayerID", playerId)
                        levelUpCmd.ExecuteNonQuery()

                        MessageBox.Show($"LEVEL UP! You are now Level {newLevel}!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        needsLevelUpCheck = False
                    End If
                Else
                    needsLevelUpCheck = False
                End If
            End While
        End Using
    End Sub

    Public Function GetQuestionsForDeck(ByVal deckId As Integer) As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Try
                Dim query As String = "SELECT * FROM Questions WHERE DeckID = @DeckID"
                Dim adapter As New SqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@DeckID", deckId)
                adapter.Fill(dt)
                Return dt
            Catch ex As Exception
                MessageBox.Show("Database Error in GetQuestionsForDeck: " & ex.Message, "Error")
                Return Nothing
            End Try
        End Using
    End Function

    Public Sub AdvancePlayerLevel(ByVal playerId As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Players SET CurrentLevel = CurrentLevel + 1 WHERE PlayerID = @PlayerID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@PlayerID", playerId)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub UpdateQuestProgress(ByVal playerId As Integer, ByVal completionType As String, Optional ByVal progressAmount As Integer = 1)
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "
            UPDATE p
            SET p.QuestProgress = p.QuestProgress + @Amount
            FROM Players p
            INNER JOIN Quests q ON p.ActiveQuestID = q.QuestID
            WHERE p.PlayerID = @PlayerID AND q.CompletionType = @Type"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@PlayerID", playerId)
            cmd.Parameters.AddWithValue("@Type", completionType)
            cmd.Parameters.AddWithValue("@Amount", progressAmount)

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function ClaimRewardAndAssignNewQuest(ByVal playerId As Integer) As Integer
        Dim quizziteRewarded As Integer = 0
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                Dim activeQuestID As Object = DB_GetPlayerActiveQuestID(playerId)

                If activeQuestID IsNot Nothing AndAlso Not IsDBNull(activeQuestID) Then
                    Dim getRewardCmd As New SqlCommand("
                    UPDATE Players SET Quizzite = Quizzite + q.Reward
                    FROM Players
                    INNER JOIN Quests q ON Players.ActiveQuestID = q.QuestID
                    WHERE Players.PlayerID = @PlayerID;
                    SELECT q.Reward FROM Quests q WHERE q.QuestID = @QuestID", conn, transaction)
                    getRewardCmd.Parameters.AddWithValue("@PlayerID", playerId)
                    getRewardCmd.Parameters.AddWithValue("@QuestID", CInt(activeQuestID))

                    Dim rewardResult = getRewardCmd.ExecuteScalar()
                    If rewardResult IsNot Nothing AndAlso Not IsDBNull(rewardResult) Then
                        quizziteRewarded = CInt(rewardResult)
                    End If
                End If

                Dim newQuestCmd As New SqlCommand("
                UPDATE Players
                SET ActiveQuestID = (
                    SELECT TOP 1 QuestID FROM Quests 
                    WHERE (@OldQuestID IS NULL OR QuestID <> @OldQuestID)
                    ORDER BY NEWID()
                ),
                QuestProgress = 0
                WHERE PlayerID = @PlayerID", conn, transaction)

                newQuestCmd.Parameters.AddWithValue("@OldQuestID", If(activeQuestID, DBNull.Value))
                newQuestCmd.Parameters.AddWithValue("@PlayerID", playerId)
                newQuestCmd.ExecuteNonQuery()

                transaction.Commit()

                If quizziteRewarded > 0 Then
                    MessageBox.Show($"Quest Complete! You earned {quizziteRewarded} Quizzite!", "Reward Claimed!")
                End If

                Return quizziteRewarded
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error processing quest: " & ex.Message, "Database Error")
                Return 0
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Helper function to get a player's active quest ID. Used internally.
    ''' </summary>
    Private Function DB_GetPlayerActiveQuestID(ByVal playerId As Integer) As Object
        Using conn As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT ActiveQuestID FROM Players WHERE PlayerID = @PlayerID", conn)
            cmd.Parameters.AddWithValue("@PlayerID", playerId)
            conn.Open()
            Return cmd.ExecuteScalar()
        End Using
    End Function

    Public Function GetQuestDetails(ByVal questId As Integer) As DataRow
        Dim dt As New DataTable()
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Quests WHERE QuestID = @QuestID"
            Dim adapter As New SqlDataAdapter(query, conn)
            adapter.SelectCommand.Parameters.AddWithValue("@QuestID", questId)
            adapter.Fill(dt)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Function GetAllCharacters() As DataTable
        Return GetDataTable("SELECT * FROM Characters ORDER BY QuizziteCost")
    End Function

    Public Function GetPlayerUnlockedCharacters(ByVal playerId As Integer) As List(Of Integer)
        Dim unlockedIds As New List(Of Integer)
        Dim dt As DataTable = GetDataTable($"SELECT CharacterID FROM PlayerUnlockedCharacters WHERE PlayerID = {playerId}")
        For Each row As DataRow In dt.Rows
            unlockedIds.Add(CInt(row("CharacterID")))
        Next
        Return unlockedIds
    End Function

    Public Function SetSelectedCharacter(ByVal playerId As Integer, ByVal characterId As Integer) As Boolean
        Return ExecuteNonQuery($"UPDATE Players SET SelectedCharacterID = {characterId} WHERE PlayerID = {playerId}")
    End Function

    Public Function AttemptCharacterPull(ByVal playerId As Integer, ByVal pullCost As Integer) As String
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                ' 1. Check player's Quizzite
                Dim checkCmd As New SqlCommand("SELECT Quizzite FROM Players WHERE PlayerID = @PlayerID", conn, transaction)
                checkCmd.Parameters.AddWithValue("@PlayerID", playerId)
                Dim currentQuizzite = CInt(checkCmd.ExecuteScalar())

                If currentQuizzite < pullCost Then
                    MessageBox.Show($"Not enough Quizzite! You need {pullCost}.", "Pull Failed")
                    Return ""
                End If

                ' 2. Find a character to unlock (one that the player DOES NOT own)
                Dim getUnownedCmd As New SqlCommand("
                SELECT TOP 1 CharacterID, CharacterName FROM Characters 
                WHERE CharacterID NOT IN (SELECT CharacterID FROM PlayerUnlockedCharacters WHERE PlayerID = @PlayerID)
                ORDER BY NEWID()", conn, transaction)
                getUnownedCmd.Parameters.AddWithValue("@PlayerID", playerId)

                Dim reader As SqlDataReader = getUnownedCmd.ExecuteReader()
                If Not reader.Read() Then
                    MessageBox.Show("Congratulations! You have unlocked all available characters!", "No More Characters")
                    reader.Close()
                    Return ""
                End If

                Dim unlockedCharId As Integer = CInt(reader("CharacterID"))
                Dim unlockedCharName As String = reader("CharacterName").ToString()
                reader.Close()

                ' 3. Subtract cost
                Dim updateCmd As New SqlCommand("UPDATE Players SET Quizzite = Quizzite - @Cost WHERE PlayerID = @PlayerID", conn, transaction)
                updateCmd.Parameters.AddWithValue("@Cost", pullCost)
                updateCmd.Parameters.AddWithValue("@PlayerID", playerId)
                updateCmd.ExecuteNonQuery()

                ' 4. Add to unlocked characters
                Dim insertCmd As New SqlCommand("INSERT INTO PlayerUnlockedCharacters (PlayerID, CharacterID) VALUES (@PlayerID, @CharID)", conn, transaction)
                insertCmd.Parameters.AddWithValue("@PlayerID", playerId)
                insertCmd.Parameters.AddWithValue("@CharID", unlockedCharId)
                insertCmd.ExecuteNonQuery()

                transaction.Commit()
                MessageBox.Show($"You unlocked: {unlockedCharName}!", "New Character!")
                Return unlockedCharName
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("An error occurred during the pull: " & ex.Message, "Error")
                Return ""
            End Try
        End Using
    End Function

    Public Function SetPlayerSelectedDeck(ByVal playerId As Integer, ByVal deckId As Integer) As Boolean

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Players SET SelectedDeckID = @DeckID WHERE PlayerID = @PlayerID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DeckID", deckId)
                cmd.Parameters.AddWithValue("@PlayerID", playerId)
                conn.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using
        End Using
    End Function

    Public Function GetCharacterData(ByVal characterId As Integer) As DataRow
        Dim dt As DataTable = GetDataTable($"SELECT * FROM Characters WHERE CharacterID = {characterId}")
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Public Sub AddPlayerQuizzite(ByVal playerId As Integer, ByVal amountToAdd As Integer)
        Using conn As New SqlConnection(connectionString)
            Dim query As String = "UPDATE Players SET Quizzite = Quizzite + @Amount WHERE PlayerID = @PlayerID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Amount", amountToAdd)
                cmd.Parameters.AddWithValue("@PlayerID", playerId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub AwardPlayerExp(ByVal playerId As Integer, ByVal expGained As Integer)
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("UPDATE Players SET CurrentEXP = CurrentEXP + @exp WHERE PlayerID = @PlayerID", conn)
            cmd.Parameters.AddWithValue("@exp", expGained)
            cmd.Parameters.AddWithValue("@PlayerID", playerId)
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable()
            Dim adapter As New SqlDataAdapter("SELECT PlayerLevel, CurrentEXP, EXPToNextLevel FROM Players WHERE PlayerID = @PlayerID", conn)
            adapter.SelectCommand.Parameters.AddWithValue("@PlayerID", playerId)
            adapter.Fill(dt)
            If dt.Rows.Count > 0 AndAlso CInt(dt.Rows(0)("CurrentEXP")) >= CInt(dt.Rows(0)("EXPToNextLevel")) Then
                AwardExpAndCheckLevelUp(playerId, 0)
            End If
        End Using
    End Sub

    Public Sub ClearStageProgress(ByVal playerId As Integer, ByVal stageLevel As Integer)
        ExecuteNonQuery($"DELETE FROM StageProgress WHERE PlayerID = {playerId} AND StageLevel = {stageLevel}")
    End Sub

    Public Sub SaveStageProgress(ByVal playerId As Integer, ByVal stageLevel As Integer, ByVal playerHP As Integer, ByVal enemyHP As Integer, ByVal compExp As Integer, ByVal compQuizzite As Integer)
        Dim query As String = "
        MERGE StageProgress AS target
        USING (SELECT @PlayerID AS PlayerID, @StageLevel AS StageLevel) AS source
        ON (target.PlayerID = source.PlayerID AND target.StageLevel = source.StageLevel)
        WHEN MATCHED THEN
            UPDATE SET PlayerCurrentHP = @PlayerHP, EnemyCurrentHP = @EnemyHP, CompensationEXP = @CompExp, CompensationQuizzite = @CompQuizzite
        WHEN NOT MATCHED THEN
            INSERT (PlayerID, StageLevel, PlayerCurrentHP, EnemyCurrentHP, CompensationEXP, CompensationQuizzite)
            VALUES (@PlayerID, @StageLevel, @PlayerHP, @EnemyHP, @CompExp, @CompQuizzite);"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PlayerID", playerId)
                cmd.Parameters.AddWithValue("@StageLevel", stageLevel)
                cmd.Parameters.AddWithValue("@PlayerHP", playerHP)
                cmd.Parameters.AddWithValue("@EnemyHP", enemyHP)
                cmd.Parameters.AddWithValue("@CompExp", compExp)
                cmd.Parameters.AddWithValue("@CompQuizzite", compQuizzite) ' Add the new parameter
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetStageProgress(ByVal playerId As Integer, ByVal stageLevel As Integer) As DataRow
        Dim dt As DataTable = GetDataTable($"SELECT PlayerCurrentHP, EnemyCurrentHP, CompensationEXP, CompensationQuizzite FROM StageProgress WHERE PlayerID = {playerId} AND StageLevel = {stageLevel}")
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
End Module