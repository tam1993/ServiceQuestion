using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NoomLibrary;

namespace ServiceQuestion
{
	public class user
	{
        public string LicensePlate { get; set; }
        public string Tel { get; set; }
        public string UType { get; set; }
        public int CustomerID { get; set; }
        public Question Question = new Question ( );

        /*SQlConnection*/
        private CStatement _CStatement;
        private CStatementList _CSQLConnection = new CStatementList ( Connection.CSQLConnection );

        public void InsertUser (){
            try {
                _CStatement = new CStatement ( "", "InsertUser", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ){
                        {"@LicensePlate", SqlDbType.VarChar, LicensePlate , ParameterDirection.Input },
                        {"@Tel", SqlDbType.VarChar, Tel , ParameterDirection.Input },
                        {"@UType", SqlDbType.VarChar, UType , ParameterDirection.Input }
                    };
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Insert );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                _CSQLConnection.Execute ( _adapter );
                _CSQLConnection.Commit ( );
            } catch(Exception ex )  {

            }
        }


        public void InsertAnswerHistory( ) {
            try {
                _CStatement = new CStatement ( "", "InsertAnswerHistory", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ){
                        {"@QuestionText", SqlDbType.VarChar, Question.QuestionText , ParameterDirection.Input },
                        {"@AnswerText", SqlDbType.VarChar, Question.AnswerText , ParameterDirection.Input },
                        {"@CustomerID", SqlDbType.VarChar, CustomerID , ParameterDirection.Input }
                    };
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Insert );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                _CSQLConnection.Execute ( _adapter );
                _CSQLConnection.Commit ( );
            } catch ( Exception ex ) {

            }
        }

        public DataTable Select_LicensePlate( ) {
            DataTable adt = new DataTable ( );
            try {
                _CStatement = new CStatement ( "Select_LicensePlate", "", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ) { 
                    {"@LicenPlate", SqlDbType.VarChar, LicensePlate , ParameterDirection.Input }
                };
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Select );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                adt = ((DataTable) _CSQLConnection.Execute ( _adapter ));
                _CSQLConnection.Commit ( );
            } catch ( Exception ) {

            }

            return adt;
        }

	}
}