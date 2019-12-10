using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add the president's names to the corresponding list box
            listBoxPresidents.Items.AddRange(new object[]
            {
                "George Washington",
                "John Adams",
                "Thomas Jefferson",
                "James Madison",
                "James Monroe",
                "John Quincy Adams",
                "Andrew Jackson",
                "Martin Van Buren",
                "William Henry Harrison",
                "John Tyler",
                "James Polk",
                "Zachary Taylor",
                "Millard Fillmore",
                "Franklin Pierce",
                "James Buchanan",
                "Abraham Lincoln",
                "Andrew Johnson",
                "Ulysses Grant",
                "Rutherford Hayes",
                "James Garfield",
                "Chester Arthur",
                "Stephen Grover Cleveland",
                "Benjamin Harrison",
                "Stephen Grover Cleveland",
                "William Mckinley",
                "Theodore Roosevelt",
                "William Taft",
                "Woodrow Wilson",
                "Warren Harding",
                "Calvin Coolidge",
                "Herbert Hoover",
                "Franklin Roosevelt",
                "Harry Truman",
                "Dwight Eisenhower",
                "John Kennedy",
                "Lyndon Johnson",
                "Richard Nixon",
                "Gerald Ford",
                "James Carter",
                "Ronald Reagan",
                "George Bush",
                "William Clinton",
                "George W Bush",
                "Barack Obama",
                "Donald Trump"
            });

            //add the info options to the corresponding list box
            listBoxInfoOptions.Items.AddRange(new object[]
            {
                "Party",
                "Start year",
                "End year",
                "Date born",
                "Date died",
                "Cause of death"
            });

            //add the categories to the corresponding combo box
            comboBoxCategory.Items.AddRange(new object[]
            {
                "Party",
                "Religion",
                "Occupation",
                "Birth state"
            });
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCategory.SelectedItem == "Party")
            {
                //clear any items in the list box
                listBoxCatVal.Items.Clear();

                //add party options to the corresponding list box
                listBoxCatVal.Items.AddRange(new object[]
                {
                    "Democratic",
                    "Republican",
                    "Federalist",
                    "Whig",
                    "Dem-Rep",
                    "No designation"
                });
            }
            else if(comboBoxCategory.SelectedItem == "Religion")
            {
                //clear any items from the list box
                listBoxCatVal.Items.Clear();

                //add religion option to the corresonding list box
                listBoxCatVal.Items.AddRange(new object[]
                {
                    "Methodist",
                    "Baptist",
                    "Episcopalian",
                    "Presbyterian",
                    "Unitarian",
                    "No affiliation"
                });
            }
            else if(comboBoxCategory.SelectedItem == "Occupation")
            {
                //clear any items from the list box
                listBoxCatVal.Items.Clear();

                //add the occupation options to the corresponding list box
                listBoxCatVal.Items.AddRange(new object[]
                {
                    "Lawyer",
                    "Soldier",
                    "Farmer",
                    "Engineer",
                    "Teacher",
                    "Actor"
                });
            }
            else
            {
                //clear any items from the list box
                listBoxCatVal.Items.Clear();

                //add the birth state options to the corresponding list box
                listBoxCatVal.Items.AddRange(new object[]
                {
                    "Virginia",
                    "Ohio",
                    "New York",
                    "Massachusetts",
                    "California",
                    "Texas"
                });
            }
        }

        private void buttonGetInfo_Click(object sender, EventArgs e)
        {
            const int QUAN_PROPERTIES = 38; //38 columns in the file
            string filePath = "C:\\Users\\stoerit\\Presidents.csv";
            string strRead;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array. one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting the records
            string[] recordParts = new string[QUAN_PROPERTIES];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                recordParts = strRead.Split(',');

                presidents[counter].FirstName = recordParts[1];
                presidents[counter].LastName = recordParts[2];
                presidents[counter].Party = recordParts[3];
                presidents[counter].StartYear = recordParts[10];
                presidents[counter].EndYear = recordParts[11];
                presidents[counter].DateBorn = recordParts[12];
                presidents[counter].DateDied = recordParts[13];
                presidents[counter].CauseOfDeath = recordParts[34];
            }
            readerClass.Close();
            fs.Close();

            int x = listBoxPresidents.SelectedIndex + 2;
            string outputString = $"{presidents[x].FirstName} {presidents[x].LastName}";

            int listInfoSelected = listBoxInfoOptions.SelectedItems.Count;
            string[] infoOptions = new string[listInfoSelected];
            int infoOptionsCount = 0;

            foreach (var infoOption in listBoxInfoOptions.SelectedItems)
            {
                infoOptions[infoOptionsCount] = infoOption.ToString();
                infoOptionsCount++;
            }

            for(int y = 0; y < infoOptions.Length; y++)
            {
                if(infoOptions[y] == "Party")
                {
                    outputString += $"\n Party: {presidents[x].Party}";
                }
                else if(infoOptions[y] == "Start year"){
                    outputString += $"\n Start year: {presidents[x].StartYear}";
                }
                else if (infoOptions[y] == "End year")
                {
                    outputString += $"\n End year: {presidents[x].EndYear}";
                }
                else if (infoOptions[y] == "Date born")
                {
                    outputString += $"\n Date born: {presidents[x].DateBorn}";
                }
                else if (infoOptions[y] == "Date died")
                {
                    outputString += $"\n Date died: {presidents[x].DateDied}";
                }
                else{
                    outputString += $"\n Cause of death: {presidents[x].CauseOfDeath}";
                }
            }

            MessageBox.Show(outputString);
        }//end buttonGetInfo_Click

        static int GetCount(string file)
        {
            int count = 0;
            string strRead;
            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader readerCount = new StreamReader(sr);

            strRead = readerCount.ReadLine(); //read the header

            while (strRead != null)
            {
                ++count;
                strRead = readerCount.ReadLine(); //read the next line
            }
            readerCount.Close();
            sr.Close();

            return count;
        }//end GetCount method

        private void buttonWriteInfo_Click(object sender, EventArgs e)
        {
            const int QUAN_PROPERTIES = 38; //38 columns in the file
            string filePath = "C:\\Users\\stoerit\\Presidents.csv";
            string strRead;
            string delim = ",";

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array. one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting the records
            string[] recordParts = new string[QUAN_PROPERTIES];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                recordParts = strRead.Split(',');

                presidents[counter].FirstName = recordParts[1];
                presidents[counter].LastName = recordParts[2];
                presidents[counter].Party = recordParts[3];
                presidents[counter].StartYear = recordParts[10];
                presidents[counter].EndYear = recordParts[11];
                presidents[counter].DateBorn = recordParts[12];
                presidents[counter].DateDied = recordParts[13];
                presidents[counter].CauseOfDeath = recordParts[34];
            }
            readerClass.Close();
            fs.Close();

            int x = listBoxPresidents.SelectedIndex + 2;
            string outputString = $"{presidents[x].FirstName} {presidents[x].LastName}'s";

            int listInfoSelected = listBoxInfoOptions.SelectedItems.Count;
            string[] infoOptions = new string[listInfoSelected];
            int infoOptionsCount = 0;

            foreach (var infoOption in listBoxInfoOptions.SelectedItems)
            {
                infoOptions[infoOptionsCount] = infoOption.ToString();
                infoOptionsCount++;
            }

            string writeString = "";

            for (int y = 0; y < infoOptions.Length; y++)
            {
                if (infoOptions[y] == "Party")
                {
                    outputString += $"\n Party: {presidents[x].Party}";
                    writeString += $"{presidents[x].Party} {delim}";
                }
                else if (infoOptions[y] == "Start year")
                {
                    outputString += $"\n Start year: {presidents[x].StartYear}";
                    writeString += $"{presidents[x].StartYear} {delim}";
                }
                else if (infoOptions[y] == "End year")
                {
                    outputString += $"\n End year: {presidents[x].EndYear}";
                    writeString += $"{presidents[x].EndYear} {delim}";
                }
                else if (infoOptions[y] == "Date born")
                {
                    outputString += $"\n Date born: {presidents[x].DateBorn}";
                    writeString += $"{presidents[x].DateBorn} {delim}";
                }
                else if (infoOptions[y] == "Date died")
                {
                    outputString += $"\n Date died: {presidents[x].DateDied}";
                    writeString += $"{presidents[x].DateDied} {delim}";
                }
                else
                {
                    outputString += $"\n Cause of death: {presidents[x].CauseOfDeath}";
                    writeString += $"{presidents[x].CauseOfDeath} {delim}";
                }
            }

            string fileWritePath = "C:\\Users\\stoerit\\PresidentsInfoOutput.csv";
            FileStream outFile2 = new FileStream(fileWritePath, FileMode.Append, FileAccess.Write);
            StreamWriter writerCSV = new StreamWriter(outFile2);

            writerCSV.WriteLine(writeString);

            writerCSV.Close();
            outFile2.Close();

            outputString += "\n selected info written to C:\\Users\\stoerit\\PresidentsInfoOutput.csv";
            MessageBox.Show(outputString);

        }//end buttonWriteInfo_Click

        private void buttonGetList_Click(object sender, EventArgs e)
        {
            const int QUAN_PROPERTIES = 38; //38 columns in the file
            string filePath = "C:\\Users\\stoerit\\Presidents.csv";
            string strRead;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array. one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting the records
            string[] recordParts = new string[QUAN_PROPERTIES];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                recordParts = strRead.Split(',');

                presidents[counter].FirstName = recordParts[1];
                presidents[counter].LastName = recordParts[2];
                presidents[counter].Party = recordParts[3];
                presidents[counter].Religion = recordParts[18];
                presidents[counter].Occupation = recordParts[20];
                presidents[counter].StateBorn = recordParts[14];
            }
            readerClass.Close();
            fs.Close();
            
            int listCalValSelected = listBoxCatVal.SelectedItems.Count;
            string[] valOptions = new string[listCalValSelected];
            int  valOptionsCount = 0;

            foreach (var valOption in listBoxCatVal.SelectedItems)
            {
                valOptions[valOptionsCount] = valOption.ToString();
                valOptionsCount++;
            }

            string presidentsOutput = "";

            for(int y = 0; y < valOptions.Length; y++)
            {
                if(valOptions[y] == "Democratic")
                {
                    for(int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Democratic")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if(valOptions[y] == "Republican")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Republican")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Federalist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Federalist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Whig")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Whig")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Dem-Rep")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Dem-Rep")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if (valOptions[y] == "No designation")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "no designation")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Methodist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Methodist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Baptist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Baptist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Episcopalian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Episcopalian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Presbyterian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Presbyterian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Unitarian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Unitarian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "No affiliation")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "no affiliation" || presidents[z].Religion == "no formal affiliation")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Lawyer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Lawyer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Soldier")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Soldier")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Farmer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Farmer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Engineer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Engineer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Teacher")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Teacher")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Actor")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Actor")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Virginia")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Virginia")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Ohio")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Ohio")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
                else if (valOptions[y] == "New York")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "New York")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Massachusetts")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Massachusetts")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
                else if (valOptions[y] == "California")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "California")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
                else
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Texas")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                        }
                    }
                }
            }

            MessageBox.Show(presidentsOutput);

        }//end buttonGetList_Click

        private void buttonWriteList_Click(object sender, EventArgs e)
        {
            const int QUAN_PROPERTIES = 38; //38 columns in the file
            string filePath = "C:\\Users\\stoerit\\Presidents.csv";
            string strRead;
            string delim = ",";

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerClass = new StreamReader(fs);

            int count = 0;
            count = GetCount(filePath); //return number of lines including header

            //create a President object array. one instance per row
            President[] presidents = new President[count];
            for (int i = 0; i < count; ++i)
            {
                presidents[i] = new President();
            }

            //getting the records
            string[] recordParts = new string[QUAN_PROPERTIES];
            for (int counter = 1; counter < count; ++counter)
            {
                strRead = readerClass.ReadLine();

                recordParts = strRead.Split(',');

                presidents[counter].FirstName = recordParts[1];
                presidents[counter].LastName = recordParts[2];
                presidents[counter].Party = recordParts[3];
                presidents[counter].Religion = recordParts[18];
                presidents[counter].Occupation = recordParts[20];
                presidents[counter].StateBorn = recordParts[14];
            }
            readerClass.Close();
            fs.Close();

            int listCalValSelected = listBoxCatVal.SelectedItems.Count;
            string[] valOptions = new string[listCalValSelected];
            int valOptionsCount = 0;

            foreach (var valOption in listBoxCatVal.SelectedItems)
            {
                valOptions[valOptionsCount] = valOption.ToString();
                valOptionsCount++;
            }

            string presidentsOutput = "";
            string writeOutput2 = "";

            for (int y = 0; y < valOptions.Length; y++)
            {
                if (valOptions[y] == "Democratic")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Democratic")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Republican")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Republican")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Federalist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Federalist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Whig")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Whig")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Dem-Rep")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "Dem-Rep")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "No designation")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Party == "no designation")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Party}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Party} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Methodist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Methodist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Baptist")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Baptist")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Episcopalian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Episcopalian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Presbyterian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Presbyterian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Unitarian")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "Unitarian")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "No affiliation")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Religion == "no affiliation" || presidents[z].Religion == "no formal affiliation")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Religion}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Religion} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Lawyer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Lawyer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Soldier")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Soldier")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Farmer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Farmer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Engineer")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Engineer")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Teacher")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Teacher")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Actor")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].Occupation == "Actor")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].Occupation}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].Occupation} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Virginia")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Virginia")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Ohio")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Ohio")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "New York")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "New York")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "Massachusetts")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Massachusetts")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
                else if (valOptions[y] == "California")
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "California")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
                else
                {
                    for (int z = 2; z < presidents.Length; z++)
                    {
                        if (presidents[z].StateBorn == "Texas")
                        {
                            presidentsOutput += $"{presidents[z].FirstName} {presidents[z].LastName} {presidents[z].StateBorn}\n";
                            writeOutput2 += $"{presidents[z].FirstName} {delim} {presidents[z].LastName} {delim} {presidents[z].StateBorn} {delim}\n";
                        }
                    }
                }
            }

            string fileWritePath = "C:\\Users\\stoerit\\PresidentsOutput.csv";
            FileStream outFile3 = new FileStream(fileWritePath, FileMode.Append, FileAccess.Write);
            StreamWriter writerCSV = new StreamWriter(outFile3);

            writerCSV.WriteLine(writeOutput2);

            writerCSV.Close();
            outFile3.Close();

            presidentsOutput += "\n selected info written to C:\\Users\\stoerit\\PresidentsOutput.csv";
            MessageBox.Show(presidentsOutput);

        }//end buttonWriteList_Click

    }//end form class

    public class President
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Party { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string DateBorn { get; set; }
        public string DateDied { get; set; }
        public string CauseOfDeath { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; }
        public string StateBorn { get; set; }
    }
}
