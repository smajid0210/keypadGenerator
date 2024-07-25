using System.Text;

namespace OldPhoneKeypad
{
    class Program
    {
        public static int[][] keyToCharacterMapper = null!;
        const string invalidInputMessage = "Invalid Input Format: ";
        public static void Main(string[] args)
        {
            string inputFilePath = "io/input.txt";
            string outputFilePath = "io/output.txt";

            keyToCharacterMapper = new int[11][];

            MapKeyToCharacters(keyToCharacterMapper);
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string input;
                    while ((input = reader.ReadLine()) != null)
                    {
                        string outputString = OldPhonePad(input);
                        writer.WriteLine(outputString);
                    }
                }
                
            }
        }

        public static string OldPhonePad(string input)
        {
            LinkedList<char> resultStringDeque = new LinkedList<char>();

            char current          = '@';
            int currentKeyCounter = -1;

            foreach(char c in input)
            {
                if(c != current && current != '@')
                {
                    try
                    {
                        resultStringDeque.AddLast((char)keyToCharacterMapper[current - 48][currentKeyCounter]);
                        currentKeyCounter = -1;
                    }

                    catch(Exception ex)
                    {
                        return invalidInputMessage + input;
                    }
                }

                if (c == '#') break;

                if (c == ' ') continue;
                
                if(c == '*')
                {
                    if (resultStringDeque.Count != 0)
                        resultStringDeque.RemoveLast();
                    
                    current           = '@';
                    currentKeyCounter = -1;
                    
                    continue;
                }

                if (c != current)
                {
                    current            = c;
                    currentKeyCounter += 1;
                }
                else
                {
                    currentKeyCounter++;
                }
            }
            StringBuilder outputStringBuilder = new StringBuilder();

            while (resultStringDeque.Count > 0)
            {
                outputStringBuilder.Append(resultStringDeque.First());
                resultStringDeque.RemoveFirst();
            }

            string output = outputStringBuilder.ToString();

            return output;
        }

        public static void MapKeyToCharacters(int[][] mapperArray)
        {
            mapperArray[0]    = new int[1];
            mapperArray[0][0] = ' ';

            mapperArray[1]    = new int[3];
            mapperArray[1][0] = '&';
            mapperArray[1][1] = '\'';
            mapperArray[1][2] = '(';

            mapperArray[2]    = new int[3];
            mapperArray[2][0] = 'A';
            mapperArray[2][1] = 'B';
            mapperArray[2][2] = 'C';

            mapperArray[3]    = new int[3];
            mapperArray[3][0] = 'D';
            mapperArray[3][1] = 'E';
            mapperArray[3][2] = 'F';

            mapperArray[4]    = new int[3];
            mapperArray[4][0] = 'G';
            mapperArray[4][1] = 'H';
            mapperArray[4][2] = 'I';

            mapperArray[5]    = new int[3];
            mapperArray[5][0] = 'J';
            mapperArray[5][1] = 'K';
            mapperArray[5][2] = 'L';

            mapperArray[6]    = new int[3];
            mapperArray[6][0] = 'M';
            mapperArray[6][1] = 'N';
            mapperArray[6][2] = 'O';

            mapperArray[7]    = new int[4];
            mapperArray[7][0] = 'P';
            mapperArray[7][1] = 'Q';
            mapperArray[7][2] = 'R';
            mapperArray[7][3] = 'S';

            mapperArray[8]    = new int[3];
            mapperArray[8][0] = 'T';
            mapperArray[8][1] = 'U';
            mapperArray[8][2] = 'V';

            mapperArray[9]    = new int[4];
            mapperArray[9][0] = 'W';
            mapperArray[9][1] = 'X';
            mapperArray[9][2] = 'Y';
            mapperArray[9][3] = 'Z';
        }
        
    }
}