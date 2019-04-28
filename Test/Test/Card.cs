using System;
using System.IO;
using System.Resources;

namespace Test
{
    public class Card
    {

        private String face;
        private String suit;

        // A/K/Q/J or Numbers 2-10
        public String Face
        { 
            get
            {
                return face;
            }
            set
            {
                // Validate and set
                switch (value)
                {
                    case ("A"):
                        face = value;
                        break;
                    case ("K"):
                        face = value;
                        break;
                    case ("Q"):
                        face = value;
                        break;
                    case ("J"):
                        face = value;
                        break;
                    case ("2"):
                        face = value;
                        break;
                    case ("3"):
                        face = value;
                        break;
                    case ("4"):
                        face = value;
                        break;
                    case ("5"):
                        face = value;
                        break;
                    case ("6"):
                        face = value;
                        break;
                    case ("7"):
                        face = value;
                        break;
                    case ("8"):
                        face = value;
                        break;
                    case ("9"):
                        face = value;
                        break;
                    case ("10"):
                        face = value;
                        break;
                    default:
                        throw new InvalidFaceException("Face can only be 'A', 'K', 'Q', 'J', or number '2'-'10'.");
                }
            }
        }

        // S/H/C/D
        public String Suit
        {
            get
            {
                return suit;
            }
            set
            {
                // Validate and set
                switch (value)
                {
                    case ("S"):
                        suit = value;
                        break;
                    case ("H"):
                        suit = value;
                        break;
                    case ("C"):
                        suit = value;
                        break;
                    case ("D"):
                        suit = value;
                        break;
                    default:
                        throw new InvalidSuitException("Suit can only be 'H', 'S', 'C', or 'D'.");
                }
            }
        }

        public Card() // default constructor
        {

        }

        public Card(String face, String suit)
        {
            this.face = face;
            this.suit = suit;
        }

        public int GetValue()
        {
            switch (face)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 10;
                case "Q":
                    return 10;
                case "K":
                    return 10;
            }
            return 1; // Ace
            
        }

        public String FileName()
        {
            String fileName = @"..\..\Resources\" + suit + face + ".gif";
            //if (File.Exists(@".\Resources\"))
            //{
            //    Console.WriteLine("exists");
            //}
            //Console.WriteLine("outside");
            return fileName;
        }

        public override string ToString()
        {
            return face + suit + " ";
        }

    }
}

[Serializable()]
public class InvalidFaceException : ArgumentException
{
    public InvalidFaceException() : base() { }
    public InvalidFaceException(string message) : base(message) { }
    public InvalidFaceException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client. 
    protected InvalidFaceException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

[Serializable()]
public class InvalidSuitException : ArgumentException
{
    public InvalidSuitException() : base() { }
    public InvalidSuitException(string message) : base(message) { }
    public InvalidSuitException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client. 
    protected InvalidSuitException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}