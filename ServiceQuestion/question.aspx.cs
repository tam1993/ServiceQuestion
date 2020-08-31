using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data;

namespace ServiceQuestion {
    public partial class question : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if ( !IsPostBack ) {
                Session[ "CollecCheck" ] = null;
                if ( Session[ "License" ] == null && Session[ "Tel" ] == null ) {
                    Response.Redirect ( @"~/Default.aspx" );
                } else {
                    DivAnswer1.Visible = false;
                    DivAnswer2.Visible = false;
                    DivAnswer3.Visible = false;
                    DivAnswer4.Visible = false;
                    DivAnswer5.Visible = false;
                    Answer1.Visible = false;
                    Answer2.Visible = false;
                    Answer3.Visible = false;
                    Answer4.Visible = false;
                    Answer5.Visible = false;
                    NotcollectHead.Visible = false;
                    collect.Visible = false;

                    DataTable dt = new DataTable ( );
                    Question q = new Question ( );
                    q.ServiceCode = int.Parse ( Session[ "ServiceCode" ].ToString ( ) );
                    dt = q.GetQuestion ( );
                    //QLabel1.Text = dt.Rows[ 0 ][ "QText" ].ToString ( );
                    //QHidden1.Value = dt.Rows[ 0 ][ "QID" ].ToString ( );

                    QLabel2.Text = dt.Rows[ 1 ][ "QText" ].ToString ( );
                    QHidden2.Value = dt.Rows[ 1 ][ "QID" ].ToString ( );

                    QLabel3.Text = dt.Rows[ 2 ][ "QText" ].ToString ( );
                    QHidden3.Value = dt.Rows[ 2 ][ "QID" ].ToString ( );

                    QLabel4.Text = dt.Rows[ 3 ][ "QText" ].ToString ( );
                    QHidden4.Value = dt.Rows[ 3 ][ "QID" ].ToString ( );

                    QLabel5.Text = dt.Rows[ 4 ][ "QText" ].ToString ( );
                    QHidden5.Value = dt.Rows[ 4 ][ "QID" ].ToString ( );


                    //getchoice
                    //Question qt1 = new Question ( );
                    //qt1.QuestionID = int.Parse ( QHidden1.Value.ToString ( ) );

                    //Q1.DataSource = qt1.GetChoice ( );
                    //Q1.DataTextField = "AText";
                    //Q1.DataValueField = "AID";
                    //Q1.DataBind ( );
                }
            } else {
                
            }

        }

        protected void Next1_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty ( Q1.SelectedValue ) ) {
                string Next1 = "Swal.fire({type: 'error',title: 'กรุณาเลือกคำตอบ'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next1, true );
            } else {
                System.Threading.Thread.Sleep ( 800 );
                question1.Visible = false;
                /******** กิจกรรม Wurth/sunday *********/
                if (Session["EventID"].ToString() == "3") {
                    SpecialQuestion1.Visible = true;
                /******** กิจกรรม ลูกค้านัดหมาย *********/
                } else if (Session["EventID"].ToString() == "5") {
                    AssignQuestion1.Visible = true;
                /******** กิจกรรมศาลาสาระ *********/
                } else if ( Session[ "EventID" ].ToString() == "4" ) {
                    question2.Visible = true;

                    //Query choice ข้อ2
                    Question qt2 = new Question ();
                    qt2.QuestionID = int.Parse ( QHidden2.Value.ToString() );

                    Q2.DataSource = qt2.GetChoice ( );
                    Q2.DataTextField = "AText";
                    Q2.DataValueField = "AID";
                    Q2.DataBind ( );
                } else{
                    
                }                
            }
        }

        protected void Next2_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty ( Q2.SelectedValue ) ) {
                string Next2 = "Swal.fire({type: 'error',title: 'กรุณาเลือกคำตอบ'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ),
                                  "ServerControlScript", Next2, true );
            }else{
                question2.Visible = false;
                question3.Visible = true;

                //Check Answer
                Question cq2 = new Question ( );
                DataTable cdt2 = new DataTable ( );
                cq2.AnswerID = int.Parse ( Q2.SelectedValue.ToString ( ) );
                cdt2 = cq2.CheckAnswer ( );
                if ( (cdt2.Rows[ 0 ][ "response" ].ToString ( )) != "collect" ) {
                    NotcollectHead.Visible = true;
                    Session[ "CollecCheck" ] = "999";
                    DivAnswer2.Visible = true;
                    Answer2.Text = cdt2.Rows[ 0 ][ "response" ].ToString ( );
                    Answer2.Visible = true;
                }

                //Query choice ข้อ3
                Question qt3 = new Question ( );
                qt3.QuestionID = int.Parse ( QHidden3.Value.ToString ( ) );

                Q3.DataSource = qt3.GetChoice ( );
                Q3.DataTextField = "AText";
                Q3.DataValueField = "AID";
                Q3.DataBind ( );
            }
            
        }
        
        protected void Next3_Click1(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty ( Q3.SelectedValue ) ) {
                string Next3 = "Swal.fire({type: 'error',title: 'กรุณาเลือกคำตอบ'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ),
                                  "ServerControlScript", Next3, true );
            } else {
                question3.Visible = false;
                question4.Visible = true;

                //Check Answer
                Question cq3 = new Question ( );
                DataTable cdt3 = new DataTable ( );
                cq3.AnswerID = int.Parse ( Q3.SelectedValue.ToString ( ) );
                cdt3 = cq3.CheckAnswer ( );
                if ( (cdt3.Rows[ 0 ][ "response" ].ToString ( )) != "collect" ) {
                    NotcollectHead.Visible = true;
                    Session[ "CollecCheck" ] = "999";
                    DivAnswer3.Visible = true;
                    Answer3.Text = cdt3.Rows[ 0 ][ "response" ].ToString ( );
                    Answer3.Visible = true;
                }

                //Query choice ข้อ4
                Question qt4 = new Question ( );
                qt4.QuestionID = int.Parse ( QHidden4.Value.ToString ( ) );

                Q4.DataSource = qt4.GetChoice ( );
                Q4.DataTextField = "AText";
                Q4.DataValueField = "AID";
                Q4.DataBind ( );
            }
        }

        protected void Next4_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty ( Q4.SelectedValue ) ) {
                string Next4 = "Swal.fire({type: 'error',title: 'กรุณาเลือกคำตอบ'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ),
                                  "ServerControlScript", Next4, true );
            } else {
                question4.Visible = false;
                question5.Visible = true;

                //Check Answer
                Question cq4 = new Question ( );
                DataTable cdt4 = new DataTable ( );
                cq4.AnswerID = int.Parse ( Q4.SelectedValue.ToString ( ) );
                cdt4 = cq4.CheckAnswer ( );
                if ( (cdt4.Rows[ 0 ][ "response" ].ToString ( )) != "collect" ) {
                    NotcollectHead.Visible = true;
                    Session[ "CollecCheck" ] = "999";
                    DivAnswer4.Visible = true;
                    Answer4.Text = cdt4.Rows[ 0 ][ "response" ].ToString ( );
                    Answer4.Visible = true;
                }

                //Query choice ข้อ5
                Question qt5 = new Question ( );
                qt5.QuestionID = int.Parse ( QHidden5.Value.ToString ( ) );

                Q5.DataSource = qt5.GetChoice ( );
                Q5.DataTextField = "AText";
                Q5.DataValueField = "AID";
                Q5.DataBind ( );
            }
        }

        protected void SendAnswer_Click(object sender, EventArgs e) {
            if ( string.IsNullOrEmpty ( Q5.SelectedValue ) ) {
                string Next5 = "Swal.fire({type: 'error',title: 'กรุณาเลือกคำตอบ'})";
                ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", Next5, true );
            } else {
                question5.Visible = false;
                ShowAnswer.Visible = true;

                //Check Answer
                Question cq5 = new Question ( );
                DataTable cdt5 = new DataTable ( );
                cq5.AnswerID = int.Parse ( Q5.SelectedValue.ToString ( ) );
                cdt5 = cq5.CheckAnswer ( );
                if ( (cdt5.Rows[ 0 ][ "response" ].ToString ( )) != "collect" ) {
                    NotcollectHead.Visible = true;
                    Session[ "CollecCheck" ] = "999";
                    DivAnswer5.Visible = true;
                    Answer5.Text = cdt5.Rows[ 0 ][ "response" ].ToString ( );
                    Answer5.Visible = true;
                }
            }

            //check คำตอบถูกหมด?
            if( Session["CollecCheck"] == null ){
                collect.Visible = true;
            }
        }

        protected void RandomReward_Click(object sender, EventArgs e) {
            Reward rw = new Reward ( );
            DataTable rdt = new DataTable ( );
            List<Question> AnswerList = (List<Question>) Session[ "Answer" ];
            string script;
            rw.LicensePlate = Session[ "License" ].ToString();
            rw.Tel = Session[ "Tel" ].ToString();

            /*สุ่มของรางวัลตามกลุ่มลูกค้า*/
            rw.UType = Session[ "UType" ].ToString ( );

            rw.ServiceCode = Session[ "ServiceCode" ].ToString();
            rw.EventID = int.Parse(Session[ "EventID" ].ToString ( ) );
            rdt = ((DataTable) rw.GetReward ( ) );

            if ( !string.IsNullOrEmpty ( rdt.Rows[ 0 ][ "RName" ].ToString ( ) ) && (rdt.Rows[ 0 ][ "RName" ].ToString ( )) != "duplicate" ) {
                rw.Rname = rdt.Rows[ 0 ][ "RName" ].ToString ( );
                rw.RID = rdt.Rows[ 0 ][ "RID" ].ToString ( );
                rw.Savelog ( );
                int CustomerID = rw.CustomerID;

                /******** กิจกรรม Wurth *********/
                if ( Session[ "EventID" ].ToString ( ) == "3" ) {
                    for ( int i = 0; i < AnswerList.Count; i++ ) {
                        user user = new user ( );
                        user.Question.QuestionText = AnswerList[ i ].QuestionText.ToString ( );
                        user.Question.AnswerText = AnswerList[ i ].AnswerText.ToString ( );
                        user.CustomerID = CustomerID;
                        user.InsertAnswerHistory ( );
                    }
                }
                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/" + rdt.Rows[ 0 ][ "img" ].ToString ( ) + "\"></img><br /><font style=\"font-size:34px;\">ยินดีด้วย</font>',allowOutsideClick: false,showConfirmButton: false})";
            } else if ( (rdt.Rows[ 0 ][ "RName" ].ToString ( )) == "duplicate" ) {
                script = "Swal.fire({type: 'error',title: 'ผิดพลาด...',html:'<font size=\"4px\">เลขทะเบียนรถใช้งานไปแล้ว</font>',allowOutsideClick: false,showConfirmButton: false})";
            } else {
                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/sala.png\"></img><br /><font style=\"font-size:34px;\">ของรางวัลพิเศษ</font>',allowOutsideClick: false,showConfirmButton: false})";
                rw.Rname = "ของรางวัลพิเศษ";
                rw.RID = "9999";
                rw.Savelog ( ); 
                int CustomerID = rw.CustomerID;

                /******** กิจกรรม Wurth *********/
                if ( Session[ "EventID" ].ToString ( ) == "3" ) {
                    for ( int i = 0; i < AnswerList.Count; i++ ) {
                        user user = new user ( );
                        user.Question.QuestionText = AnswerList[ i ].QuestionText.ToString ( );
                        user.Question.AnswerText = AnswerList[ i ].AnswerText.ToString ( );
                        user.CustomerID = CustomerID;
                        user.InsertAnswerHistory ( );
                    }
                }
            }

            ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", script, true );

            string tmpServicecode = Session[ "ServiceCode" ].ToString ( );
            string tmpEventID = Session[ "EventID" ].ToString ( );
            Session.Clear ( );
            Session[ "ServiceCode" ] = tmpServicecode;
            Session[ "EventID" ] = tmpEventID;
        }

        protected void SPQ1BTN_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = new List<Question>();
            qlist.Add ( new Question { QuestionText = SpecialQuestionText.Text, AnswerText = SPQ1.SelectedItem.Text } );
            Session[ "Answer" ] = qlist;
            SpecialQuestion1.Visible = false;
            SpecialQuestion2.Visible = true;
            //collect.Visible = true;
            //ShowAnswer.Visible = true;
            //System.Threading.Thread.Sleep ( 500 );
        }

        protected void SPQ2BTN_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>) Session[ "Answer" ];
            qlist.Add ( new Question { QuestionText = SpecialQuestionText2.Text, AnswerText = SPQ2.SelectedItem.Text } );
            Session[ "Answer" ] = qlist;
            SpecialQuestion2.Visible = false;
            SpecialQuestion3.Visible = true;
        }

        protected void SPQ3BTN_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>) Session[ "Answer" ];
            qlist.Add ( new Question { QuestionText = SpecialQuestionText3.Text, AnswerText = SPQ3.SelectedItem.Text } );
            Session[ "Answer" ] = qlist;
            SpecialQuestion3.Visible = false;
            SpecialQuestion4.Visible = true;
        }

        protected void SPQ4BTN_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>) Session[ "Answer" ];
            qlist.Add ( new Question { QuestionText = SpecialQuestionText4.Text, AnswerText = SPQ4.SelectedItem.Text } );
            Session[ "Answer" ] = qlist;
            SpecialQuestion4.Visible = false;
            SpecialQuestion5.Visible = true;
        }

        protected void SPQ4BT5_Click(object sender, ImageClickEventArgs e) {
            
            Reward rw = new Reward ( );
            rw.UType = Session[ "UType" ].ToString ( );
            rw.ServiceCode = Session[ "ServiceCode" ].ToString ( );
            rw.EventID = int.Parse ( Session[ "EventID" ].ToString ( ) );
            rw.LicensePlate = Session[ "License" ].ToString ( );
            rw.Tel = Session[ "Tel" ].ToString ( );



            rw.Rname = "ไม่มีของรางวัล";
            rw.RID = "000000000";
            rw.Savelog();
            int CustomerID = rw.CustomerID;
            List<Question> qlist = (List<Question>)Session["Answer"];
            qlist.Add(new Question { QuestionText = SpecialQuestionText5.Text, AnswerText = SPQ5.SelectedItem.Text });

            string script = "";

            for (int i = 0; i < qlist.Count; i++) {
                user user = new user();
                user.Question.QuestionText = qlist[i].QuestionText.ToString();
                user.Question.AnswerText = qlist[i].AnswerText.ToString();
                user.CustomerID = CustomerID;
                user.InsertAnswerHistory();
            }
            //ขอบคุน
            script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/sala.png\"></img>',allowOutsideClick: false,showConfirmButton: false})";


            /*
            //สุ่มรางวัล
            DataTable rdt = new DataTable();
            //สุ่มของรางวัลตามกลุ่มลูกค้า
            rdt = ((DataTable)rw.GetReward());
            //แสดงรางวัล
            int CustomerID=0;
            if (!string.IsNullOrEmpty(rdt.Rows[0]["RName"].ToString()) && (rdt.Rows[0]["RName"].ToString()) != "duplicate") {
                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/" + rdt.Rows[0]["img"].ToString() + "\"></img><br /><font style=\"font-size:34px;\">ยินดีด้วย</font>',allowOutsideClick: false,showConfirmButton: false})";

                rw.Rname = rdt.Rows[0]["RName"].ToString();
                rw.RID = rdt.Rows[0]["RID"].ToString();
                rw.Savelog();
                CustomerID = rw.CustomerID;

                List<Question> qlist = (List<Question>)Session["Answer"];
                qlist.Add(new Question { QuestionText = SpecialQuestionText5.Text, AnswerText = SPQ5.SelectedItem.Text });

                for (int i = 0; i < qlist.Count; i++) {
                    user user = new user();
                    user.Question.QuestionText = qlist[i].QuestionText.ToString();
                    user.Question.AnswerText = qlist[i].AnswerText.ToString();
                    user.CustomerID = CustomerID;
                    user.InsertAnswerHistory();
                }


                SpecialQuestion5.Visible = false;
            } else if ((rdt.Rows[0]["RName"].ToString()) == "duplicate") {
                script = "Swal.fire({type: 'error',title: 'ผิดพลาด...',html:'<font size=\"4px\">เลขทะเบียนรถใช้งานไปแล้ว</font>',allowOutsideClick: false,showConfirmButton: false})";
            } else {
                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/sala.png\"></img><br /><font style=\"font-size:34px;\">ของรางวัลพิเศษ</font>',allowOutsideClick: false,showConfirmButton: false})";
                rw.Rname = "ไม่มีของรางวัล";
                rw.RID = "000000000";
                rw.Savelog();
                CustomerID = rw.CustomerID;


                List<Question> qlist = (List<Question>)Session["Answer"];
                qlist.Add(new Question { QuestionText = SpecialQuestionText5.Text, AnswerText = SPQ5.SelectedItem.Text });

                for (int i = 0; i < qlist.Count; i++) {
                    user user = new user();
                    user.Question.QuestionText = qlist[i].QuestionText.ToString();
                    user.Question.AnswerText = qlist[i].AnswerText.ToString();
                    user.CustomerID = CustomerID;
                    user.InsertAnswerHistory();
                }

                SpecialQuestion5.Visible = false;
            }
            */











            ScriptManager.RegisterStartupScript ( this, GetType ( ), "ServerControlScript", script, true );

            string tmpServicecode = Session[ "ServiceCode" ].ToString ( );
            string tmpEventID = Session[ "EventID" ].ToString ( );
            Session.Clear ( );
            Session[ "ServiceCode" ] = tmpServicecode;
            Session[ "EventID" ] = tmpEventID;
        }

        protected void AssignQuestionBtn1_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = new List<Question>();
            qlist.Add(new Question { QuestionText = AssignQuestionText1.Text, AnswerText = AssignAnswer1.SelectedItem.Text });
            Session["Answer"] = qlist;
            AssignQuestion1.Visible = false;
            AssignQuestion2.Visible = true;
        }

        protected void AssignQuestionBtn2_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>)Session["Answer"];
            qlist.Add(new Question { QuestionText = AssignQuestionText2.Text, AnswerText = AssignAnswer2.SelectedItem.Text });
            Session["Answer"] = qlist;
            AssignQuestion2.Visible = false;
            AssignQuestion3.Visible = true;
        }

        protected void AssignQuestionBtn3_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>)Session["Answer"];
            qlist.Add(new Question { QuestionText = AssignQuestionText3.Text, AnswerText = AssignAnswer3.SelectedItem.Text });
            Session["Answer"] = qlist;
            AssignQuestion3.Visible = false;
            AssignQuestion4.Visible = true;
        }

        protected void AssignQuestionBtn4_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>)Session["Answer"];
            qlist.Add(new Question { QuestionText = AssignQuestionText4.Text, AnswerText = AssignAnswer4.SelectedItem.Text });
            Session["Answer"] = qlist;
            AssignQuestion4.Visible = false;
            AssignQuestion5.Visible = true;
        }

        protected void AssignQuestionBtn5_Click(object sender, ImageClickEventArgs e) {
            List<Question> qlist = (List<Question>)Session["Answer"];
            qlist.Add(new Question { QuestionText = AssignQuestionText5.Text, AnswerText = AssignAnswer5.SelectedItem.Text });
            Session["Answer"] = qlist;
            AssignQuestion5.Visible = false;
            AssignRandomReward.Visible = true;
        }

        protected void AssignRandomRewardBtn_Click(object sender, EventArgs e) {
            string script = "";

            Reward rw = new Reward();
            rw.UType = Session["UType"].ToString();
            rw.ServiceCode = Session["ServiceCode"].ToString();
            rw.EventID = int.Parse(Session["EventID"].ToString());
            rw.LicensePlate = Session["License"].ToString();
            rw.Tel = Session["Tel"].ToString();


            DataTable rdt = ((DataTable)rw.GetReward());

            if (!string.IsNullOrEmpty(rdt.Rows[0]["RName"].ToString()) && (rdt.Rows[0]["RName"].ToString()) != "duplicate") {
                rw.Rname = rdt.Rows[0]["RName"].ToString();
                rw.RID = rdt.Rows[0]["RID"].ToString();
                rw.Savelog();
                int CustomerID = rw.CustomerID;

                List<Question> qlist = (List<Question>)Session["Answer"];

                for (int i = 0; i < qlist.Count; i++) {
                    user user = new user();
                    user.Question.QuestionText = qlist[i].QuestionText.ToString();
                    user.Question.AnswerText = qlist[i].AnswerText.ToString();
                    user.CustomerID = CustomerID;
                    user.InsertAnswerHistory();
                }

                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<font style=\"font-size:38px;\">ได้รับ : " + rdt.Rows[0]["RName"].ToString() + "</font>',allowOutsideClick: false,showConfirmButton: false})";
            } else if ((rdt.Rows[0]["RName"].ToString()) == "duplicate") {
                script = "Swal.fire({type: 'error',title: 'ผิดพลาด...',html:'<font size=\"4px\">เลขทะเบียนรถใช้งานไปแล้ว</font>',allowOutsideClick: false,showConfirmButton: false})";
            } else {
                rw.Rname = "ของรางวัลพิเศษ";
                rw.RID = "9999";
                rw.Savelog();
                int CustomerID = rw.CustomerID;

                List<Question> qlist = (List<Question>)Session["Answer"];

                for (int i = 0; i < qlist.Count; i++) {
                    user user = new user();
                    user.Question.QuestionText = qlist[i].QuestionText.ToString();
                    user.Question.AnswerText = qlist[i].AnswerText.ToString();
                    user.CustomerID = CustomerID;
                    user.InsertAnswerHistory();
                }

                script = "Swal.fire({type: 'success',title: 'ขอบคุณที่ร่วมกิจกรรม',html:'<img src=\"img/sala.png\"></img><br /><font style=\"font-size:34px;\">ของรางวัลพิเศษ</font>',allowOutsideClick: false,showConfirmButton: false})";
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            string tmpServicecode = Session["ServiceCode"].ToString();
            string tmpEventID = Session["EventID"].ToString();
            Session.Clear();
            Session["ServiceCode"] = tmpServicecode;
            Session["EventID"] = tmpEventID;

        }
    }
}