using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using NoomLibrary;

namespace ServiceQuestion
{
	public class Reward
	{
        public string UType { get; set; }
        public string LicensePlate { get; set; }
        public string Tel { get; set; }
        public string Rname { get; set; }
        public string RID { get; set; }
        public string ServiceCode { get; set; }
        public string DatestampStart { get; set; }
        public string DatestampEnd { get; set; }
        public int EventID { get; set; }
        public int CustomerID { get; set; }

        /*SQlConnection*/
        private CStatement _CStatement;
        private CStatementList _CSQLConnection = new CStatementList ( Connection.CSQLConnection );

        public DataTable GetReward( ) {
            DataTable dt = new DataTable ( );
            object res = null;
            try {
                _CStatement = new CStatement ( "GetReward", "", "", "", CommandType.StoredProcedure );
                CSQLDataAdepterList _gadapter = new CSQLDataAdepterList ( );
                CSQLParameterList _gparameter = new CSQLParameterList ( ){
                        {"@UType", SqlDbType.VarChar, UType , ParameterDirection.Input },
                        {"@LicensePlate", SqlDbType.VarChar, LicensePlate , ParameterDirection.Input },
                        {"@Tel", SqlDbType.VarChar, Tel , ParameterDirection.Input },
                        {"@ServiceCode", SqlDbType.VarChar, ServiceCode , ParameterDirection.Input }
                    };
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _gparameter, NoomLibrary.StatementType.Select );

                _gadapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                res = _CSQLConnection.Execute ( _gadapter );
                _CSQLConnection.Commit ( );
                _CSQLConnection.Close ( );
                dt = ((DataTable) res);
            } catch ( Exception ) { 
            
            }
            return dt;
        }

        public DataTable GetRewardHistory( ) {
            DataTable dt = new DataTable ( );
            object res = null;
            try {
                _CStatement = new CStatement ( "Select_RewardHistory", "", "", "", CommandType.StoredProcedure );
                CSQLDataAdepterList _gadapter = new CSQLDataAdepterList ( );
                CSQLParameterList _gparameter = new CSQLParameterList ( ){
                        {"@date", SqlDbType.VarChar, DatestampStart, ParameterDirection.Input },
                        {"@dateend", SqlDbType.VarChar, DatestampEnd, ParameterDirection.Input },
                        {"@serviceCode", SqlDbType.VarChar, ServiceCode , ParameterDirection.Input },
                        {"@EventID", SqlDbType.Int, EventID , ParameterDirection.Input }
                    };
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _gparameter, NoomLibrary.StatementType.Select );

                _gadapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                res = _CSQLConnection.Execute ( _gadapter );
                _CSQLConnection.Commit ( );
                _CSQLConnection.Close ( );
                dt = ((DataTable) res);
            } catch ( Exception ) {

            }
            return dt;
        }

        public DataTable GetRewardHistoryGraph( ) {
            DataTable dt = new DataTable ( );
            object res = null;
            try {
                _CStatement = new CStatement ( "Select_RewardHistoryGraph", "", "", "", CommandType.StoredProcedure );
                CSQLDataAdepterList _gadapter = new CSQLDataAdepterList ( );
                CSQLParameterList _gparameter = new CSQLParameterList ( ){
                        {"@date", SqlDbType.VarChar, DatestampStart, ParameterDirection.Input },
                        {"@dateend", SqlDbType.VarChar, DatestampEnd, ParameterDirection.Input },
                        {"@serviceCode", SqlDbType.VarChar, ServiceCode , ParameterDirection.Input },
                        {"@EventID", SqlDbType.Int, EventID , ParameterDirection.Input }
                    };
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _gparameter, NoomLibrary.StatementType.Select );

                _gadapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                res = _CSQLConnection.Execute ( _gadapter );
                _CSQLConnection.Commit ( );
                _CSQLConnection.Close ( );
                dt = ((DataTable) res);
            } catch ( Exception ) {

            }
            return dt;
        }

        public DataTable GetCustomerHistory( ) {
            DataTable dt = new DataTable ( );
            object res = null;
            try {
                _CStatement = new CStatement ( "Select_CustomerHistory", "", "", "", CommandType.StoredProcedure );
                CSQLDataAdepterList _gadapter = new CSQLDataAdepterList ( );
                CSQLParameterList _gparameter = new CSQLParameterList ( ){
                        {"@date", SqlDbType.VarChar, DatestampStart, ParameterDirection.Input },
                        {"@dateend", SqlDbType.VarChar, DatestampEnd, ParameterDirection.Input },
                        {"@serviceCode", SqlDbType.VarChar, ServiceCode , ParameterDirection.Input },
                        {"@EventID", SqlDbType.Int, EventID , ParameterDirection.Input }
                    };
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _gparameter, NoomLibrary.StatementType.Select );

                _gadapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                res = _CSQLConnection.Execute ( _gadapter );
                _CSQLConnection.Commit ( );
                _CSQLConnection.Close ( );
                dt = ((DataTable) res);
            } catch ( Exception ) {

            }
            return dt;
        }

        public void Savelog( ) {
            try {
                _CStatement = new CStatement ( "", "InsertHistory", "", "", CommandType.StoredProcedure );
                CSQLDataAdepterList _adapter = new CSQLDataAdepterList ( );
                CSQLParameterList _parameter = new CSQLParameterList ( ){
                        {"@InsertLicensePlate", SqlDbType.VarChar, LicensePlate , ParameterDirection.Input },
                        {"@InsertTel", SqlDbType.VarChar, Tel , ParameterDirection.Input },
                        {"@InsertRName", SqlDbType.VarChar, Rname , ParameterDirection.Input },
                        {"@InsertRID", SqlDbType.VarChar, RID , ParameterDirection.Input },
                        {"@InsertUType", SqlDbType.VarChar, UType , ParameterDirection.Input },
                        {"@InsertServiceCode", SqlDbType.VarChar, ServiceCode , ParameterDirection.Input },
                        {"@InsertEventID", SqlDbType.Int, EventID , ParameterDirection.Input },
                        {"@RegisterID", SqlDbType.Int, ParameterDirection.Output }
                    };
                CSQLStatementValue _csv = new CSQLStatementValue ( _CStatement, _parameter, NoomLibrary.StatementType.Insert );

                _adapter.Add ( _csv );
                /*execute*/
                _CSQLConnection.Open ( );
                _CSQLConnection.Execute ( _adapter );
                CustomerID = int.Parse ( _parameter[ "@RegisterID" ].Value.ToString ( ) );
                _CSQLConnection.Commit ( );
                _CSQLConnection.Close ( );
            } catch ( Exception ) { 
            
            }
        }

	}
}