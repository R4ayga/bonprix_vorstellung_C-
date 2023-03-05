using System;
using System.Collections.Generic;

namespace CSharpQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisieren der Fragen
            List<Question> questions = InitQuestions();

            // Index der aktuellen Frage und Punktestand des Benutzers
            int currentQuestionIndex = 0;
            int score = 0;

            // Solange es noch unbeantwortete Fragen gibt
            while (currentQuestionIndex < questions.Count)
            {
                // Aktuelle Frage auswählen
                Question question = questions[currentQuestionIndex];

                // Frage und Antworten ausgeben
                Console.WriteLine(question.Text);
                for (int i = 0; i < question.Answers.Length; i++)
                {
                    Console.WriteLine((i + 1) + ") " + question.Answers[i]);
                }

                // Benutzereingabe abfragen
                Console.Write("Ihre Antwort: ");
                string input = Console.ReadLine();

                // Prüfen, ob die Eingabe eine Zahl zwischen 1 und der Anzahl der Antworten ist
                int selectedAnswerIndex;
                bool isNumeric = int.TryParse(input, out selectedAnswerIndex);
                if (isNumeric && selectedAnswerIndex >= 1 && selectedAnswerIndex <= question.Answers.Length)
                {
                    // Antwort auswählen
                    string selectedAnswer = question.Answers[selectedAnswerIndex - 1];

                    // Prüfen, ob die Antwort korrekt ist
                    if (selectedAnswer == question.CorrectAnswer)
                    {
                        // Punktestand erhöhen und Erfolgsmeldung ausgeben
                        score++;
                        Console.WriteLine("Richtig!");
                    }
                    else
                    {
                        // Fehlermeldung ausgeben
                        Console.WriteLine("Falsch!");
                    }

                    // Index der nächsten Frage erhöhen
                    currentQuestionIndex++;
                }
                else
                {
                    // Ungültige Eingabe, Fehlermeldung ausgeben
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und " + question.Answers.Length + " ein.");
                }

                // Leere Zeile ausgeben, um den Output übersichtlicher zu gestalten
                Console.WriteLine();
            }

            // Abschlussmeldung ausgeben
            Console.WriteLine("Sie haben das Quiz abgeschlossen!\n\nIhre Punktzahl: " + score + "/" + questions.Count);

            // Auf Eingabe warten, damit die Konsole nicht direkt geschlossen wird
            Console.ReadLine();
        }

        // Methode zur Initialisierung der Fragen
        static List<Question> InitQuestions()
        {
            List<Question> questions = new List<Question>();
            questions.Add(new Question("Was ist die Hauptstadt von Deutschland?", new string[] { "Berlin", "Hamburg", "München", "Köln" }, "Berlin"));
            questions.Add(new Question("Wie viele Kontinente gibt es?", new string[] { "5", "6", "7", "8" }, "7"));
            questions.Add(new Question("Wie lautet der Codename für die erste Version von C#?", new string[] { "C#", "COOL", "Salamander", "Panther" }, "COOL"));
            return questions;
        }
    }

    // Klasse zur Darstellung von Fragen
    public class Question
    {
        public string Text { get; set; } // Text der Frage
        public string[] Answers
        {
        public string CorrectAnswer { get; set; } // Richtige Antwort

        // Konstruktor
        public Question(string text, string[] answers, string correctAnswer)
        {
            Text = text;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}