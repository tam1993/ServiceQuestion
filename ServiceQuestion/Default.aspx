<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ServiceQuestion._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="Styles/startpage.css" rel="stylesheet" type="text/css" />
  <style>
  .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
      }
     .cover-container
     {
         position: relative;
     }
     .font-xx{
         font-size:x-large;
         }
    ul
    {
        font-size: 17pt;
        color: #ffcccc;
    }
  </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods = "true"/>

<div class="cover-container d-flex w-100 h-100 p-3 mx-auto flex-column" id=ServiceSelect runat=server>
    <main role="main" class="inner cover" style="margin-top:120px;" id="a">&nbsp;<p class="lead">&nbsp;</p>
        <asp:DropDownList ID="ServiceCode" CssClass="form-control font-xx" runat="server">
            <asp:ListItem Value='none'>เลือกสาขา</asp:ListItem>
            <asp:ListItem Value='40130201'>สาขาหน้าปรินส์</asp:ListItem>
            <asp:ListItem Value='40130202'>สาขาจอมทอง</asp:ListItem>
            <asp:ListItem Value='40130203'>สาขาสันป่าตอง</asp:ListItem>
            <asp:ListItem Value='40130204'>สาขาดอนจั่น</asp:ListItem>
            <asp:ListItem Value='40130205'>สาขาสันทราย</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="EventDropdown" CssClass="form-control font-xx" runat="server" />
        <br />
        <center>
            <asp:Button ID="Button2" CssClass="btn btn-lg btn-success" runat="server" Text="บันทึก" onclick="Button2_Click" />
        </center>
    </main>
</div>

<div id=ServiceSelected class="cover-container d-flex w-100 h-100 p-3 mx-auto flex-column" runat=server style="text-align:center;">
<%--เลือกกลุ่มลูกค้า--%>
  <div role="main" runat=server visible=false class="inner cover" style="margin-top:120px;" id="a">&nbsp;<p class="lead">&nbsp;</p>
    <p class="lead">
        <img src="img/sala.png"/ style="margin-top: -90px;height: 310px; width: 360px;">
    </p>
    <h2 style="margin-top:-20px;">ร่วมสนุกตอบคำถามง่ายๆเพื่อลุ้นของรางวัล</h2>  <br /> 
    <div class="form-group">
            <br />
                            <center>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:RadioButtonList  RepeatLayout="Flow" RepeatDirection="Horizontal" id="type" runat="server" style="font-size:20px;" required>
                    <asp:ListItem Value="assign">&nbsp&nbsp<img src="img/call.png" style="width:70px;height:70px"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:ListItem>
                    <asp:ListItem Value="walkin">&nbsp&nbsp<img src="img/car.png" style="width:70px;height:70px"/></asp:ListItem>
                </asp:RadioButtonList>
                
            </center>
        </div> 
        <br />
        <a href="#" id="btnTest" >
            <asp:ImageButton ID="next" ImageUrl="img/start.png" runat="server" 
          style="height:100px; margin-top: 10px;" onclick="next_Click" />
        </a>

        <%--<asp:LinkButton ID="btnTest" href="#" runat="server">
            <img id="Img1" src="img/start.png" style="height:20%; margin-top: 10px;"/>
        </asp:LinkButton>--%>
  </div>

<%--กรอกข้อมูล--%>
  <div id="b" runat=server style="padding-top:33px">
    <form>
        <div class="form-group">
            <center style="margin-top:80px;" runat=server visible=false id="SalaLogo" >
                <img src="img/sala.png" style="height: 250px; width: 300px;" >
            </center>
            
            <center style="margin-top:80px;" runat=server id="wurth" visible=false>
                <img alt="sala" src="img/sala.png" style="height: 250px; width: 300px;">
                <%--&nbsp&nbsp&nbsp
                <img alt="wurth" src="img/wuerth_logo.png" style="height: 130px; width: 440px;">--%>
            </center>
            <label for="LicensePlate" style="font-size:30px;">ทะเบียนรถ</label>
            <asp:TextBox ID="LicensePlate" CssClass="form-control form-control-lg" placeholder="กรอกทะเบียนรถ (กก1234 ชม)" AutoComplete="off" required runat="server" />
            <ajaxToolkit:AutoCompleteExtender MinimumPrefixLength="1" CompletionInterval="20" EnableCaching="false" ID="AutoCompleteExtender1" ServiceMethod="SearchLiecnsePlace" TargetControlID="LicensePlate" FirstRowSelected=false runat="server" />
        </div>
        <%--<div class="form-group">
            <label for="LicensePlate" style="font-size:30px;">ที่อยู่</label>
            <asp:TextBox ID="TextBox1" CssClass="form-control form-control-lg" placeholder="กรอกที่อยู่" AutoComplete="off" required runat="server" />
        </div>--%>
        <div class="form-group">
            <label for="Tel" style="font-size:30px;">เบอร์โทร</label>
            <asp:TextBox ID="Tel" class="form-control form-control-lg" placeholder="กรอกเบอร์โทร (0876543211)" maxlength="10" required AutoComplete="off" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="Tel" runat="server" ErrorMessage="<font color='red' size=16px>กรอกเฉพาะตัวเลข</font>" ValidationExpression="\d+" >
        </asp:RegularExpressionValidator>
        </div>

        
        <asp:Button ID="Button1" runat="server" style="font-size:50px;" CssClass="btn btn-danger btn-lg" 
            Text="   ยืนยัน    " onclick="Button1_Click" />
    </form>
  </div>
    <br />
</div>

</asp:Content>
