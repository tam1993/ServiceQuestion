using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NoomLibrary;

namespace ServiceQuestion
{
	public class Question
	{
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public int ServiceCode { get; set; }
        public string QuestionText { get; set; }

        /*SQlConnection*/
        private CStatement _CStatement;
        private CStatementList _CSQLConnection = new CStatementList ( Connection.CSQLConnection );

        public DataTable GetQuestion( ) { 
            DataTable dt = new DataTable ();
            try {
                _CStatement = new CStatement ( "GetQuestion", "", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ){ 
                    {"@ServiceCode", SqlDbType.Int, ServiceCode , ParameterDirection.Input }
                };
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Select );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                dt = ((DataTable) _CSQLConnection.Execute ( _adapter ) );
                _CSQLConnection.Commit ( );
                return dt;
            } catch ( Exception ex ) { 
                
            }
            return dt;
        }

        public DataTable GetChoice( ) {
            DataTable cdt = new DataTable ( );
            try {
                _CStatement = new CStatement ( "GetChoice", "", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ) { 
                    {"@QuestionID", SqlDbType.Int, QuestionID , ParameterDirection.Input }
                };
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Select );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                cdt = ((DataTable) _CSQLConnection.Execute ( _adapter ));
                _CSQLConnection.Commit ( );
            } catch (Exception) { 
            
            }
            return cdt;
        }

        public DataTable CheckAnswer( ) {
            DataTable adt = new DataTable ( );
            try {
                _CStatement = new CStatement ( "CheckAnswer", "", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ) { 
                    {"@AID", SqlDbType.Int, AnswerID , ParameterDirection.Input }
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

        public DataTable GetEvent( ) {
            DataTable dt = new DataTable ( );
            try {
                _CStatement = new CStatement ( "GetEvent", "", "", "", CommandType.StoredProcedure );
                CSQLParameterList _parameter = new CSQLParameterList ( ) ;
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Select );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                dt = ((DataTable) _CSQLConnection.Execute ( _adapter ));
                _CSQLConnection.Commit ( );
            } catch ( Exception ) {

            }
            return dt;
        }
	}
}