<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Report.aspx.cs" Inherits="ServiceQuestion.manage" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <title>รายงาน</title>
    <script src="Scripts/chartjs.js" type="text/javascript"></script>
    <style>
        .font-xx{
            font-size:x-large;
         }
         .green {
             color: #2cc185;
        }
        text {
            font-size:16px;
            font-family:Sarabun;
            height: 100%;
            margin: 0;
        }
        
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="col-md-10 container" runat=server style="margin-top:50px;">
            <div class="row">
                <div class="col-md-4">
                    <asp:DropDownList ID="ServiceCode" CssClass="form-control font-xx" runat="server">
                        <asp:ListItem Value='none'>เลือกสาขา</asp:ListItem>
                        <asp:ListItem Value='all'>ทุกสาขา</asp:ListItem>
                        <asp:ListItem Value='40130201'>สาขาหน้าปรินส์</asp:ListItem>
                        <asp:ListItem Value='40130202'>สาขาจอมทอง</asp:ListItem>
                        <asp:ListItem Value='40130203'>สาขาสันป่าตอง</asp:ListItem>
                        <asp:ListItem Value='40130204'>สาขาดอนจั่น</asp:ListItem>
                        <asp:ListItem Value='40130205'>สาขาสันทราย</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:DropDownList ID="EventDropdown" CssClass="form-control font-xx" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:TextBox ID="TextBox1" CssClass="form-control form-control-sm font-xx" runat="server" AutoComplete=off placeholder="เลือกวันที่" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TextBox1"  />
                </div>
                <div class="col-md-1">
                    <asp:TextBox ID="TextBox2" CssClass="form-control form-control-sm font-xx" runat="server" AutoComplete=off placeholder="เลือกวันที่" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TextBox2"  />
                </div>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Button ID="Button1" CssClass="btn btn-success font-xx" runat="server" Text="แสดงข้อมูล" onclick="Button1_Click" />
            </div>

            <nav>
              <div class="nav nav-tabs" id="nav-tab" role="tablist">
                <a class="nav-item nav-link" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">ตาราง</a>
                <a class="nav-item nav-link active" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">กราฟ</a>
              </div>
            </nav>
            <div class="tab-content" id="nav-tabContent">
              <div class="tab-pane fade" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                    <br />
                    <!-- Gridview -->
                    <div id="Div1" style="overflow: scroll;overflow-y: auto;overflow-x: hidden;height: 500px;" runat=server>
                    <asp:GridView ID="GridView1" CssClass="table table-dark" runat="server" AutoGenerateColumns=false>
                        <Columns>
                            <asp:TemplateField HeaderText = "ป้ายทะเบียน">
                                <ItemTemplate>
                                    <asp:Label ID="ULicensePlate" runat="server" Text='<%# Eval("ULicensePlate") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText = "เบอร์โทร">
                                <ItemTemplate>
                                    <asp:Label ID="UTel" runat="server" Text='<%# Eval("UTel") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText = "ของรางวัล">
                                <ItemTemplate>
                                    <asp:Label ID="RName" runat="server" Text='<%# Eval("RName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText = "เวลา">
                                <ItemTemplate>
                                    <asp:Label ID="DateStamp" runat="server" Text='<%# Eval("DateStamp") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText = "สาขา">
                                <ItemTemplate>
                                    <asp:Label ID="ServiceName" runat="server" Text='<%# Eval("ServiceName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText = "ประเภทลูกค้า">
                                <ItemTemplate>
                                    <asp:Label ID="UType" runat="server" Text='<%# Eval("UType") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <h1>ไม่พบข้อมูล</h1>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    </div>
              </div>
              <div class="tab-pane fade show active" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                    <!-- Graph -->
                    <div class="row">
                        <div class="card col-md-7" >
                            <div class="card-body">
                            <h5 class="card-title">Graph</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                            <%--<ajaxToolkit:PieChart ID="pieChart1" CssClass="font-xx" BorderWidth=0px runat="server" ChartHeight="300" ChartWidth="450" Visible=false/>--%>
                            <canvas id="myChart" ></canvas>
                            </div>
                        </div>

                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                        <div class="card col-md-3" >
                            <div class="card-body">
                            <h5 class="card-title">ลูกค้าทั้งหมด</h5>
                            <h6 class="card-subtitle mb-2 font-xx green" runat=server id=all>0</h6>
                                <hr />
                            <h5 class="card-title">ลูกค้านัดหมาย</h5>
                            <h6 class="card-subtitle mb-2 font-xx green" runat=server id=assign>0</h6>
                                <hr />
                            <h5 class="card-title">ลูกค้าไม่ได้นัดหมาย</h5>
                            <h6 class="card-subtitle mb-2 font-xx green" runat=server id=walkin>0</h6>
                                <hr />
                            <h5 class="card-title">อื่นๆ</h5>
                            <h6 class="card-subtitle mb-2 font-xx green" runat=server id=other>0</h6>
                            </div>
                        </div>
                    </div>
              </div>
            </div>

            

            
        </div>

        
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>