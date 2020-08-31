using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ServiceQuestion {
    public partial class manage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Select_Event();
            } else { 
                
            }
        }

        protected void Select_Event() {
            try {
                Question qt = new Question();
                EventDropdown.DataSource = qt.GetEvent();
                EventDropdown.DataValueField = "EventID";
                EventDropdown.DataTextField = "EventName";
                EventDropdown.DataBind();
                EventDropdown.Items.Insert(0, new ListItem("เลือกกิจกรรม", "none"));
            } catch (Exception) { 
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Reward rw = new Reward ( );
            try {
                rw.ServiceCode = ServiceCode.SelectedValue;
                System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
                DateTime date1 = Convert.ToDateTime(TextBox1.Text);
                rw.DatestampStart = date1.ToString("yyyy-MM-dd");
                DateTime date2 = Convert.ToDateTime(TextBox2.Text);
                rw.DatestampEnd = date2.ToString("yyyy-MM-dd");
                rw.EventID = int.Parse(EventDropdown.SelectedValue);
                DataTable dt = new DataTable();
                dt = rw.GetRewardHistory();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                DataTable cdt = new DataTable();
                cdt = rw.GetCustomerHistory();
                all.InnerText = cdt.Rows[0]["allType"].ToString();
                assign.InnerText = cdt.Rows[0]["assign"].ToString();
                walkin.InnerText = cdt.Rows[0]["walkin"].ToString();
                other.InnerText = cdt.Rows[0]["other"].ToString();

                DataTable gdt = new DataTable();
                gdt = rw.GetRewardHistoryGraph();
                if (dt.Rows.Count > 0) {
                    var RndColor = new List<string> { "rgba(255, 99, 132, 0.8)", "rgba(54, 162, 235, 0.8)", "rgba(255, 206, 86, 0.8)", "rgba(20, 159, 64, 0.8)", "rgba(75, 215, 235, 0.8)", "rgba(100, 5, 235, 0.8)" };
                    var RndBorder = new List<string> { "rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(20, 159, 64, 1)", "rgba(75, 215, 235, 1)", "rgba(100, 5, 235, 1)" };
                    string ChartLabelreturn = "[", ChartDataReturn = "[", ChartColorReturn = "[", ChartBorderReturn = "[";
                    for (int i = 0; i <= gdt.Rows.Count - 1; i++) {
                        if (i < gdt.Rows.Count - 1) {
                            ChartLabelreturn = ChartLabelreturn + "'" + gdt.Rows[i]["RName"].ToString() + "(" + gdt.Rows[i]["Total"].ToString() + ")',";
                            ChartDataReturn = ChartDataReturn + gdt.Rows[i]["Total"].ToString() + ",";
                            ChartColorReturn = ChartColorReturn + "'" + RndColor[i] + "',";
                            ChartBorderReturn = ChartBorderReturn + "'" + RndBorder[i] + "',";
                        } else {
                            ChartLabelreturn = ChartLabelreturn + "'" + gdt.Rows[i]["RName"].ToString() + "(" + gdt.Rows[i]["Total"].ToString() + ")'";
                            ChartDataReturn = ChartDataReturn + gdt.Rows[i]["Total"].ToString();
                            ChartColorReturn = ChartColorReturn + "'" + RndColor[i] + "'";
                            ChartBorderReturn = ChartBorderReturn + "'" + RndBorder[i] + "'";
                        }
                    }
                    ChartLabelreturn = ChartLabelreturn + "]";
                    ChartDataReturn = ChartDataReturn + "]";
                    ChartColorReturn = ChartColorReturn + "]";
                    ChartBorderReturn = ChartBorderReturn + "]";

                    string GraphText = "var ctx = document.getElementById('myChart').getContext('2d'); var myChart = new Chart(ctx, { type: 'doughnut',options: { tooltips: { titleFontSize: 20, bodyFontSize: 20 },legend: { labels: { fontColor: '#2cc185', fontSize: 18 } } }, data: { labels: " + ChartLabelreturn + ", datasets: [{ label: '# of Votes', data: " + ChartDataReturn + ", backgroundColor: " + ChartColorReturn + ", borderColor: " + ChartBorderReturn + ", borderWidth: 1 }] } });";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", GraphText, true);
                } else {
                    string Err = "Swal.fire({type: 'error',title: 'ไม่พบข้อมูล'})";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", Err, true);
                }
            } catch (Exception ex) {
                string Err = "Swal.fire({type: 'error',title: '"+ex.Message+"'})";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", Err, true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            Reward rw = new Reward();
            try {
                rw.ServiceCode = ServiceCode.SelectedValue;
                System.Globalization.CultureInfo _cultureEnInfo = new System.Globalization.CultureInfo("en-US");
                DateTime date1 = Convert.ToDateTime(TextBox1.Text);
                rw.DatestampStart = date1.ToString("yyyy-MM-dd");
                DateTime date2 = Convert.ToDateTime(TextBox2.Text);
                rw.DatestampEnd = date2.ToString("yyyy-MM-dd");
                rw.EventID = int.Parse(EventDropdown.SelectedValue);
                DataTable dt = new DataTable();
                dt = rw.GetRewardHistory();
                GridView1.DataSource = dt;
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
                string Script = "$('#nav-profile').removeClass('active');$('#nav-home').tab('show');$('#nav-profile-tab').removeClass('active');$('#nav-home-tab').addClass('active');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", Script, true);
            } catch (Exception) { 
                
            }
            
        }
    }
}