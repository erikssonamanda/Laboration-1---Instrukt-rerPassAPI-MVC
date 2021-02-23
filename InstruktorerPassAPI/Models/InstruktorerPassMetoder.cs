using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; 

namespace InstruktorerPassAPI.Models
{
    /* InstruktorerPassMetoder är en klass som innehåller alla metoder för verben GET, POST, PUT 
    * och DELETE för tabellerna Tbl_Instruktorer, Tbl_InstruktorerPass och Tbl_Pass. 
   */
    public class InstruktorerPassMetoder
    {
        /* ALLA GET-METODER. HÄMTAR DATA FRÅN DATABASEN 
         * Beskrivning: Dessa metoder hämtar data från databasen om instruktörerna, passen, vilka pass en 
         *              instruktör har och alla instruktörer ett pass har. 
         */

        /* Metod: GetAllaInstruktorer
         * Beskrivning: Denna metod hämtar alla instruktörer som finns i databasen
         * Returnerar: En lista med alla instruktörer 
         */
        public List<Instruktorer> GetAllaInstruktorer(out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source = (LocalDb)\MSSQLLocalDb; Initial Catalog = InstruktorerDB; Integrated Security = True"
            };

            String sqlString = "SELECT * FROM Tbl_Instruktorer";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            List<Instruktorer> instruktorerList = new List<Instruktorer>();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "InstruktorerTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerTbl"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        Instruktorer instruktorDetalj = new Instruktorer();
                        instruktorDetalj.In_Id = Convert.ToInt32(dataset.Tables["InstruktorerTbl"].Rows[i]["In_Id"]);
                        instruktorDetalj.In_Fornamn = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Fornamn"].ToString();
                        instruktorDetalj.In_Efternamn = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Efternamn"].ToString();
                        instruktorDetalj.In_Adress = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Adress"].ToString();
                        instruktorDetalj.In_Postnummer = Convert.ToInt32(dataset.Tables["InstruktorerTbl"].Rows[i]["In_Postnummer"]);
                        instruktorDetalj.In_Ort = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Ort"].ToString();
                        instruktorDetalj.In_Epost = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Epost"].ToString();
                        instruktorDetalj.In_Mobil = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Mobil"].ToString();
                        instruktorDetalj.In_Personnummer = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Personnummer"].ToString();

                        i++;
                        instruktorerList.Add(instruktorDetalj);
                    }
                    errormsg = "Det gick inte att hämta alla instruktörer från databasen!";
                    return instruktorerList;
                }
                else
                {
                    errormsg = "Det hämtas ingen instruktör från databasen!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /*  Metod: GetInstruktor
         *  Beskrivning: Denna metod hämtar en specifik instruktör som finns i databasen
         *  Returnerar: En instruktör baserat på det valda id:et 
         */
        public Instruktorer GetInstruktor(int instruktorId, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_Instruktorer WHERE In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = instruktorId;

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            try
            {
                dbConnection.Open();

                adapter.Fill(dataset, "InstruktorerTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerTbl"].Rows.Count;

                if (count > 0)
                {
                    Instruktorer instruktorDetalj = new Instruktorer();
                    instruktorDetalj.In_Id = Convert.ToInt32(dataset.Tables["InstruktorerTbl"].Rows[i]["In_Id"]);
                    instruktorDetalj.In_Fornamn = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Fornamn"].ToString();
                    instruktorDetalj.In_Efternamn = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Efternamn"].ToString();
                    instruktorDetalj.In_Adress = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Adress"].ToString();
                    instruktorDetalj.In_Postnummer = Convert.ToInt32(dataset.Tables["InstruktorerTbl"].Rows[i]["In_Postnummer"]);
                    instruktorDetalj.In_Ort = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Ort"].ToString();
                    instruktorDetalj.In_Epost = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Epost"].ToString();
                    instruktorDetalj.In_Mobil = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Mobil"].ToString();
                    instruktorDetalj.In_Personnummer = dataset.Tables["InstruktorerTbl"].Rows[i]["In_Personnummer"].ToString();

                    errormsg = "Ingen instruktör med det valda id:et finns!";
                    return instruktorDetalj;

                }
                else
                {
                    errormsg = "Det hämtas ingen instruktör. Kontrollera id!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetAllaPass
         * Beskrivning: Denna metod hämtar alla aktiviteter som finns i databasen
         * Returnerar: En lista med alla aktiviteter 
         */
        public List<Pass> GetAllaPass(out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_Pass";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            List<Pass> passList = new List<Pass>();

            try
            {
                dbConnection.Open();

                adapter.Fill(dataset, "PassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["PassTbl"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        Pass passDetalj = new Pass();
                        passDetalj.Pa_Id = Convert.ToInt32(dataset.Tables["PassTbl"].Rows[i]["Pa_Id"]);
                        passDetalj.Pa_Aktivitet = dataset.Tables["PassTbl"].Rows[i]["Pa_Aktivitet"].ToString();

                        i++;
                        passList.Add(passDetalj);
                    }
                    errormsg = "Det gick inte att hämta alla aktiviteter!";
                    return passList;
                }
                else
                {
                    errormsg = "Ingen aktivitet hämtas från databasen!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetPass
         * Beskrivning: Denna metod hämtar en specifik aktivitet som finns i databasen
         * Returnerar: En aktivitet baserat på det valda id:et 
         */
        public Pass GetPass(int passId, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_Pass WHERE Pa_Id = @Pa_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("Pa_Id", SqlDbType.Int).Value = passId;

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "PassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["PassTbl"].Rows.Count;

                if (count > 0)
                {
                    Pass passDetalj = new Pass();
                    passDetalj.Pa_Id = Convert.ToInt32(dataset.Tables["PassTbl"].Rows[i]["Pa_Id"]);
                    passDetalj.Pa_Aktivitet = dataset.Tables["PassTbl"].Rows[i]["Pa_Aktivitet"].ToString();

                    errormsg = "Ingen aktivitet med det valda id:et finns!";
                    return passDetalj;
                }
                else
                {
                    errormsg = "Det hämtas ingen aktivitet. Kontrollera id!";
                    return null;
                }

            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetInstruktorerHarPass
         * Beskrivning: Denna metod hämtar en lista med alla aktiviteter som instruktörerna har 
         * Returnerar: En lista med instruktörernas aktiviteter 
         */
        public List<InstruktorerPass> GetInstruktorerHarPass(out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_InstruktorerPass";
            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            List<InstruktorerPass> instruktorerHarPass = new List<InstruktorerPass>();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "InstruktorerPassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerPassTbl"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        InstruktorerPass instruktorerPassDetalj = new InstruktorerPass();
                        instruktorerPassDetalj.IP_Id = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_Id"]);
                        instruktorerPassDetalj.IP_InstruktorId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_InstruktorId"]);
                        instruktorerPassDetalj.IP_PassId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_PassId"]);

                        i++;
                        instruktorerHarPass.Add(instruktorerPassDetalj);
                    }
                    errormsg = "Det gick inte att hämta alla pass med tillhörande instruktörer!";
                    return instruktorerHarPass;
                }
                else
                {
                    errormsg = "Inget pass med tillhörande intruktörer hämtas!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetInstruktorensPass
         * Beskrivning: Denna metod hämtar en lista med alla aktiviteter som en specifik instruktörerna har 
         * Returnerar: En lista med den specifika instruktörens aktiviteter 
         */
        public List<InstruktorerPass> GetInstruktorensPass(int instuktorId, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_InstruktorerPass WHERE IP_InstruktorId = @IP_InstruktorId";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("IP_InstruktorId", SqlDbType.Int).Value = instuktorId;

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            List<InstruktorerPass> instruktorensPass = new List<InstruktorerPass>();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "InstruktorerPassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerPassTbl"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        InstruktorerPass instruktorerPassDetalj = new InstruktorerPass();
                        instruktorerPassDetalj.IP_Id = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_Id"]);
                        instruktorerPassDetalj.IP_InstruktorId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_InstruktorId"]);
                        instruktorerPassDetalj.IP_PassId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_PassId"]);

                        i++;
                        instruktorensPass.Add(instruktorerPassDetalj);
                    }
                    errormsg = "Alla aktiviteter som instruktören har hämtas inte!";
                    return instruktorensPass;
                }
                else
                {
                    errormsg = "Inget av instruktörens pass hämtas!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetInstruktorensPassDetalj
         * Beskrivning: Denna metod hämtar en lista med alla aktiviteter som en specifik instruktörerna har 
         * Returnerar: En lista med den specifika instruktörens aktiviteter 
         */
        public InstruktorerPass GetInstruktorensPassDetalj(int id, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_InstruktorerPass WHERE IP_Id = @IP_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("IP_Id", SqlDbType.Int).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            InstruktorerPass instruktorensPass = new InstruktorerPass();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "InstruktorerPassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerPassTbl"].Rows.Count;

                if (count > 0)
                {
                    InstruktorerPass instruktorerPassDetalj = new InstruktorerPass();
                    instruktorerPassDetalj.IP_Id = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_Id"]);
                    instruktorerPassDetalj.IP_InstruktorId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_InstruktorId"]);
                    instruktorerPassDetalj.IP_PassId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_PassId"]);

                    errormsg = "Ingen information med det valda id:et finns att hämta!";
                    return instruktorerPassDetalj;
                }
                else
                {
                    errormsg = "Det hämtas ingen information. Kontrollera id!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: GetPassetsInstruktorer
         * Beskrivning: Denna metod hämtar en lista med alla instruktörer som en specifik aktivitet har 
         * Returnerar: En lista med den specifika aktivitetens instruktörer
         */
        public List<InstruktorerPass> GetPassetsInstruktorer(int passId, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection()
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "SELECT * FROM Tbl_InstruktorerPass WHERE IP_PassId = @IP_PassId";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("IP_PassId", SqlDbType.Int).Value = passId;

            SqlDataAdapter adapter = new SqlDataAdapter(dbCommand);
            DataSet dataset = new DataSet();

            List<InstruktorerPass> passetsInstruktorer = new List<InstruktorerPass>();

            try
            {
                dbConnection.Open();
                adapter.Fill(dataset, "InstruktorerPassTbl");

                int count = 0;
                int i = 0;
                count = dataset.Tables["InstruktorerPassTbl"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                    {
                        InstruktorerPass instruktorerPassDetalj = new InstruktorerPass();
                        instruktorerPassDetalj.IP_Id = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_Id"]);
                        instruktorerPassDetalj.IP_InstruktorId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_InstruktorId"]);
                        instruktorerPassDetalj.IP_PassId = Convert.ToInt32(dataset.Tables["InstruktorerPassTbl"].Rows[i]["IP_PassId"]);

                        i++;
                        passetsInstruktorer.Add(instruktorerPassDetalj);
                    }
                    errormsg = "Alla instruktörer för den valda aktiviteten hämtas inte!";
                    return passetsInstruktorer;
                }
                else
                {
                    errormsg = "Inga instruktörer för den valda aktiviteten hämtas!";
                    return null;
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* ALLA POST-METODER. LÄGGER TILL DATA I DATABASEN 
         * Beskrivning: Dessa metoder lägger till data i databasen. Metoderna lägger till instruktörer, pass 
         *              och tilldelar pass till olika instruktörer. 
         */

        /* Metod: PostInstruktor 
         * Beskrivning: Denna metod lägger till en ny instruktör i databasen
         * Returnerar: Den nya instruktören som har lagts till 
         */
        public int PostInstruktor(Instruktorer nyInstruktor, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "INSERT INTO Tbl_Instruktorer (In_Fornamn, In_Efternamn, In_Adress, In_Postnummer, In_Ort, In_Epost, In_Mobil, In_Personnummer) " +
                               "VALUES (@In_Fornamn, @In_Efternamn, @In_Adress, @In_Postnummer, @In_Ort, @In_Epost, @In_Mobil, @In_Personnummer)";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Fornamn", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Fornamn;
            dbCommand.Parameters.Add("In_Efternamn", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Efternamn;
            dbCommand.Parameters.Add("In_Adress", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Adress;
            dbCommand.Parameters.Add("In_Postnummer", SqlDbType.Int).Value = nyInstruktor.In_Postnummer;
            dbCommand.Parameters.Add("In_Ort", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Ort;
            dbCommand.Parameters.Add("In_Epost", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Epost;
            dbCommand.Parameters.Add("In_Mobil", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Mobil;
            dbCommand.Parameters.Add("In_Personnummer", SqlDbType.NVarChar, 50).Value = nyInstruktor.In_Personnummer;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det skapas inte någon ny instruktör i databasen!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: PostPass
         * Beskrivning: Denna metod lägger till en ny aktivitet i databasen
         * Returnerar: Den nya aktiviteten som har lagts till 
         */
        public int PostPass(Pass nyttPass, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "INSERT INTO Tbl_Pass (Pa_Aktivitet) VALUES (@Pa_Aktivitet)";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("Pa_Aktivitet", SqlDbType.NVarChar, 50).Value = nyttPass.Pa_Aktivitet;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det skapas ingen ny aktivitet i databasen!";
                }
                return (i);

            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: PostInstruktorHarPass
         * Beskrivning: Denna metod lägger till en ny aktivitet till en specifik instruktör 
         * Returnerar: Den nya aktiteten och dess instruktör
         */
        public int PostInstruktorHarPass(InstruktorerPass nyInstruktorHarPass, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "INSERT INTO Tbl_InstruktorerPass (IP_InstruktorId, IP_PassId) VALUES (@IP_InstruktorId, @IP_PassId)";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("IP_InstruktorId", SqlDbType.Int).Value = nyInstruktorHarPass.IP_InstruktorId;
            dbCommand.Parameters.Add("IP_PassId", SqlDbType.Int).Value = nyInstruktorHarPass.IP_PassId;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att lägga till passet till den valda instruktören. Kontrollera id!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* ALLA PUT-METODER. UPPDATERAR DATA I DATABASEN 
         * Beskrivning: Dessa metoder uppdaterar data i databasen om instruktörerna, passen och vilka pass en 
         *              instruktör har. 
         */

        /* Metod: PutEfternamn
         * Beskrivning: Denna metod uppdaterar/ändrar efternamnet på en specifik instruktör 
         * Returnerar: Instruktören med det nya efternamnet
         */
        public int PutEfternamn(int id, string efternamn, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "UPDATE Tbl_Instruktorer SET In_Efternamn = @In_Efternamn WHERE In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = id;
            dbCommand.Parameters.Add("In_Efternamn", SqlDbType.NVarChar, 50).Value = efternamn;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att uppdatera efternamnet för den valda instruktören!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: PutAdress
         * Beskrivning: Denna metod uppdaterar/ändrar adressen för en specifik instruktör 
         * Returnerar: Instruktören med den nya adressen
         */
        public int PutAdress(int id, Instruktorer nyAdress, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "UPDATE Tbl_Instruktorer " +
                               "SET In_Adress = @In_Adress, In_Postnummer = @In_Postnummer, In_Ort = @In_Ort " +
                               "WHERE In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = id;
            dbCommand.Parameters.Add("In_Adress", SqlDbType.NVarChar, 50).Value = nyAdress.In_Adress;
            dbCommand.Parameters.Add("In_Postnummer", SqlDbType.Int).Value = nyAdress.In_Postnummer;
            dbCommand.Parameters.Add("In_Ort", SqlDbType.NVarChar, 50).Value = nyAdress.In_Ort;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att uppdatera addressen för den valda instruktören!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: PutEpost
         * Beskrivning: Denna metod uppdaterar/ändrar eposten på en specifik instruktör 
         * Returnerar: Instruktören med den nya eposten
         */
        public int PutEpost(int id, string epost, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "UPDATE Tbl_Instruktorer " +
                               "SET Tbl_Instruktorer.In_Epost = @In_Epost " +
                               "WHERE Tbl_Instruktorer.In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = id;
            dbCommand.Parameters.Add("In_Epost", SqlDbType.NVarChar, 50).Value = epost;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att uppdatera eposten för den valda instruktören!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: PutMobil
         * Beskrivning: Denna metod uppdaterar/ändrar mobilnumret på en specifik instruktör 
         * Returnerar: Instruktören med det nya mobilnumret
         */
        public int PutMobil(int id, string mobil, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "UPDATE Tbl_Instruktorer " +
                               "SET Tbl_Instruktorer.In_Mobil = @In_Mobil " +
                               "WHERE Tbl_Instruktorer.In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = id;
            dbCommand.Parameters.Add("In_Mobil", SqlDbType.NVarChar, 50).Value = mobil;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att uppdatera mobilnumret för den valda instruktören!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* ALLA DELETE-METODER. TAR BORT DATA FRÅN DATABASEN 
         * Beskrivning: Dessa metoder tar bort data från databasen om instruktörerna, passen och vilka pass en 
         *              instruktör har. 
         */

        /* Metod: DeleteInstruktor
         * Beskrivning: Denna metod raderar en instruktör från databasen
         * Returnerar: Ett meddelande som säger att instruktören har blivit borttagen från databasen 
         */
        public int DeleteInstruktor(int id, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "DELETE FROM Tbl_Instruktorer WHERE In_Id = @In_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("In_Id", SqlDbType.Int).Value = id;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att ta bort den valda instruktören från databasen!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: DeletePass
         * Beskrivning: Denna metod raderar en aktivitet från databasen
         * Returnerar: Ett meddelande som säger att aktiviteten har blivit borttagen från databasen 
         */
        public int DeletePass(int id, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "DELETE FROM Tbl_Pass WHERE Pa_Id = @Pa_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("Pa_Id", SqlDbType.Int).Value = id;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att ta bort den valda aktiviteten från databasen!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /* Metod: DeleteInstruktorHarPass
         * Beskrivning: Denna metod raderar en aktivitet från en specifik instruktör i databasen
         * Returnerar: Ett meddelande som säger att aktiviteten har blivit borttagen från den specifika instruktören  
         */
        public int DeleteInstruktorHarPass(int id, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection
            {
                ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDb;Initial Catalog=InstruktorerDB;Integrated Security=True"
            };

            string sqlString = "DELETE FROM Tbl_InstruktorerPass WHERE IP_Id = @IP_Id";

            SqlCommand dbCommand = new SqlCommand(sqlString, dbConnection);

            dbCommand.Parameters.Add("IP_Id", SqlDbType.Int).Value = id;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    errormsg = "";
                }
                else
                {
                    errormsg = "Det gick inte att ta bort aktiviteten från den valda instruktören!";
                }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
