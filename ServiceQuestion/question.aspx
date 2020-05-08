<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="ServiceQuestion.question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/slicknav.min.css"/>
	<link rel="stylesheet" href="Styles/owl.carousel.min.css"/>
	<link rel="stylesheet" href="Styles/magnific-popup.css"/>
	<link rel="stylesheet" href="Styles/animate.css"/>
    <link href="Styles/funkyradio.css" rel="stylesheet" type="text/css" />
	<!-- Main Stylesheets -->
	<link rel="stylesheet" href="Styles/style.css"/>

    <style>
    .modal1 {
        position: fixed;
        background-color: #ECEBEB;
        top: 0;
        left: 0;
        height: 100%;
        width: 100%;
        /*z-index: 10;*/
        opacity: 0.99;
        z-index: 100002 !important;
    }
    .center1 {
        z-index: 1000000;
        margin: 200px auto;
        padding: 10px;
        width: 25%;
        /* background-color: White; */
        border-radius: 10px;
        filter: alpha(opacity=100);
        opacity: 1;
        -moz-opacity: 1;
    }
    .center1 img {
        height: auto;
        width: 100%;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<!-- Page Preloder -->
	<div id="preloder">
		<div class="loader"></div>
	</div>
    
    <asp:HiddenField ID="QHidden1" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="QHidden2" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="QHidden3" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="QHidden4" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="QHidden5" runat="server"></asp:HiddenField>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal1">
                <div class="center1">
                    <%--<div class="fade-in">--%>
                    <asp:Image ID="Image1" ImageUrl="img/loadingnew.gif" runat="server" />
                    <%--</div>--%>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
        <section class="hero-section" style="margin-top:-200px;">
            <!-- question1 -->
            <div ID="question1" runat="server">
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#1</font>
                            <asp:Label ID="QLabel1" runat="server" style="font-size:35px;color:#000000;">ลูกค้ารู้จักอีซูซุศาลาเชียงใหม่สาขาใดบ้าง?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:CheckBoxList ID="Q1" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">
                                        <asp:ListItem>สาขาดอนจั่น</asp:ListItem>
                                        <asp:ListItem>สาขาสันป่าตอง</asp:ListItem>
                                        <asp:ListItem>สาขาจอมทอง</asp:ListItem>
                                        <asp:ListItem>สาขาสันทราย</asp:ListItem>
                                        <asp:ListItem>สาขาหน้าปรินส์</asp:ListItem>
                                    </asp:CheckBoxList>
                                    <%--<asp:RadioButtonList ID="Q1" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                    <asp:ListItem>ดอนจั่น</asp:ListItem>
                                    <asp:ListItem>สันป่าตอง</asp:ListItem>
                                    <asp:ListItem>จอมทอง</asp:ListItem>
                                    <asp:ListItem>สันทราย</asp:ListItem>
                                    <asp:ListItem>หน้าปริ้น</asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="Next1" ImageUrl="img/next.png" style="width:200px;" runat="server" onclick="Next1_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>
                
            <!-- question2 -->
            <div id="question2" runat=server visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center" >
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:200px;">
					        <font size="50px" style="color:#ff0000;">#2</font>
					        <asp:Label ID="QLabel2" runat="server" style="font-size:45px;color:#000000;"></asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="Q2" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:30px;">                                        
                                        </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="Next2" ImageUrl="img/next.png" style="width:200px;" runat="server" autopostback="true" onclick="Next2_Click"></asp:ImageButton>
				    </div>
			    </div>
            </div>

            <!-- question3 -->
            <div id="question3" runat=server visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center" >
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:200px;">
					        <font size="50px" style="color:#ff0000;">#3</font>
					        <asp:Label ID="QLabel3" runat="server" style="font-size:45px;color:#000000;"></asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="Q3" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:30px;">                                        
                                        </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="Next3" ImageUrl="img/next.png" style="width:200px;" runat="server" autopostback="true" 
                            onclick="Next3_Click1"></asp:ImageButton>
				    </div>
			    </div>
            </div>

            <!-- question4 -->
            <div id="question4" runat=server visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center" >
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:200px;">
					        <font size="50px" style="color:#ff0000;">#4</font>
					        <asp:Label ID="QLabel4" runat="server" style="font-size:45px;color:#000000;"></asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="Q4" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:30px;">                                        
                                        </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="Next4" ImageUrl="img/next.png" style="width:200px;" runat="server" autopostback="true" 
                            onclick="Next4_Click"></asp:ImageButton>
				    </div>
			    </div>
            </div>

            <!-- question5 -->
            <div id="question5" runat=server visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center" >
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:200px;">
					        <font size="50px" style="color:#ff0000;">#5</font>
					        <asp:Label ID="QLabel5" runat="server" style="font-size:45px;color:#000000;"></asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="Q5" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:30px;">                                        
                                        </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SendAnswer" ImageUrl="img/next.png" style="width:200px;" runat="server" autopostback="true" onclick="SendAnswer_Click"></asp:ImageButton>
				    </div>
			    </div>
            </div>

             <!-- SpecialQuestion1 -->
            <div ID="SpecialQuestion1" runat="server" visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#2</font>
                            <asp:Label ID="SpecialQuestionText" runat="server" style="font-size:35px;color:#000000;">ลูกค้าสะดวกเข้ารับบริการวันไหน?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="SPQ1" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                        <asp:ListItem Value="วันเสาร์" Text="วันเสาร์" />
                                        <asp:ListItem Value="วันอาทิตย์" Text="วันอาทิตย์" />
                                        <asp:ListItem Value="ทุกวัน" Text="ทุกวัน" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SPQ1BTN" ImageUrl="img/next.png" style="width:200px;" 
                            runat="server" onclick="SPQ1BTN_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>

            <!-- SpecialQuestion2 -->
            <div ID="SpecialQuestion2" runat="server" visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#3</font>
                            <asp:Label ID="SpecialQuestionText2" runat="server" style="font-size:35px;color:#000000;">ช่วงเวลาที่ลูกค้าสะดวก?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="SPQ2" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                        <asp:ListItem Value="8-10" Text="8-10" />
                                        <asp:ListItem Value="10-12" Text="10-12" />
                                        <asp:ListItem Value="13-15" Text="13-15" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SPQ2BTN" ImageUrl="img/next.png" style="width:200px;" runat="server" onclick="SPQ2BTN_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>

            <!-- SpecialQuestion3 -->
            <div ID="SpecialQuestion3" runat="server" visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#4</font>
                            <asp:Label ID="SpecialQuestionText3" runat="server" style="font-size:35px;color:#000000;">การบริการครั้งนี้ลูกค้าประทับใจอะไรบ้าง?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="SPQ3" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                        <asp:ListItem Value="วัน-เวลาที่ให้บริการ" Text="วัน-เวลาที่ให้บริการ" />
                                        <asp:ListItem Value="อาหาร-เครื่องดื่ม และสิ่งอำนวยความสะดวก" Text="อาหาร-เครื่องดื่ม และสิ่งอำนวยความสะดวก" />
                                        <asp:ListItem Value="ของที่ระลึก" Text="ของที่ระลึก" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SPQ3BTN" ImageUrl="img/next.png" style="width:200px;" runat="server" onclick="SPQ3BTN_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>

            <!-- SpecialQuestion4 -->
            <div ID="SpecialQuestion4" runat="server" visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#5</font>
                            <asp:Label ID="SpecialQuestionText4" runat="server" style="font-size:35px;color:#000000;">ความพึงพอใจในการให้บริการ?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="SPQ4" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                        <asp:ListItem Value="มาก" Text="มาก" />
                                        <asp:ListItem Value="ปานกลาง" Text="ปานกลาง" />
                                        <asp:ListItem Value="น้อย" Text="น้อย" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SPQ4BTN" ImageUrl="img/next.png" style="width:200px;" 
                            runat="server" onclick="SPQ4BTN_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>

            <!-- SpecialQuestion5 -->
            <div ID="SpecialQuestion5" runat="server" visible=false>
                <div class="hero-item d-flex align-items-center justify-content-center text-center">
				    <div class="container">
                        <div class="bd-callout bd-callout-info col-md-10 offset-md-1" style="background-color:#ffffff;margin-top:250px;">
					        <font style="color:#ff0000;font-size:36px;">#6</font>
                            <asp:Label ID="SpecialQuestionText5" runat="server" style="font-size:35px;color:#000000;">ลูกค้าสนใจจะร่วมกิจกรรมในครั้งต่อไปหรือไม่?</asp:Label>
                        </div>
                        <center>
                            <div class="col-md-10 offset-md-1">
                                <div class="funkyradio">
                                    <asp:RadioButtonList ID="SPQ5" runat="server" CssClass="funkyradio-success col-md-12" style="font-size:22px;">                                        
                                        <asp:ListItem Value="สนใจ" Text="สนใจ" />
                                        <asp:ListItem Value="ไม่มั่นใจ" Text="ไม่มั่นใจ" />
                                        <asp:ListItem Value="ไม่สนใจ" Text="ไม่สนใจ" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </center>
                        <br />

                        <asp:ImageButton ID="SPQ4BT5" ImageUrl="img/next.png" style="width:200px;" runat="server" onclick="SPQ4BT5_Click" />
                        <br />
                        <br />
				    </div>
			    </div>
            </div>

            <!-- ShowAnswer -->
            <div id="ShowAnswer" runat=server visible=false style="margin-top:80px;">
                <div class="hero-item d-flex align-items-center justify-content-center text-center" >
				    <div class="container">
                        <asp:Label ID="NotcollectHead" runat="server" style="font-size:80px;color:#ff0000;" Text="สาระน่ารู้"></asp:Label> 
                        <br />
                        <div class="bd-callout bd-callout-warning col-md-10 offset-md-1" style="background-color:#ffffff;" id="DivAnswer1" runat=server>
                            <asp:Label ID="Answer1" runat="server" style="font-size:28px;"></asp:Label>
                        </div>
                        <div class="bd-callout bd-callout-warning col-md-10 offset-md-1" style="background-color:#ffffff;" id="DivAnswer2" runat=server>
                            <asp:Label ID="Answer2" runat="server" style="font-size:28px;"></asp:Label>
                        </div>
                        <div class="bd-callout bd-callout-warning col-md-10 offset-md-1" style="background-color:#ffffff;" id="DivAnswer3" runat=server>
                            <asp:Label ID="Answer3" runat="server" style="font-size:28px;"></asp:Label>
                        </div>
                        <div class="bd-callout bd-callout-warning col-md-10 offset-md-1" style="background-color:#ffffff;" id="DivAnswer4" runat=server>
                            <asp:Label ID="Answer4" runat="server" style="font-size:28px;"></asp:Label>
                        </div>
                        <div class="bd-callout bd-callout-warning col-md-10 offset-md-1" style="background-color:#ffffff;" id="DivAnswer5" runat=server>
                            <asp:Label ID="Answer5" runat="server" style="font-size:28px;"></asp:Label>
                        </div>

                        <img id="collect" src="img/lion.png" runat=server />

                        <br /><br /><br />

                        <asp:Button ID="RandomReward" runat="server" Text="         สุ่มของรางวัล         " Font-Size="30px" CssClass="btn btn-success" autopostback="true" onclick="RandomReward_Click" ></asp:Button>
                    </div>
                </div>
            </div>
	</section>


    </ContentTemplate>
    </asp:UpdatePanel>
    
       
    <script src="Scripts/jquery.slicknav.min.js"></script>
	<script src="Scripts/owl.carousel.min.js"></script>
	<script src="Scripts/jquery.sticky-sidebar.min.js"></script>
	<script src="Scripts/jquery.magnific-popup.min.js"></script>
	<script src="Scripts/main.js"></script>

</asp:Content>
