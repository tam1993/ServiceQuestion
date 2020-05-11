<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ServiceQuestion.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>จัดการ</title>
    <style type ="text/css">
        body {
            font-size:18px;
        }
        code {
            color : aqua;
            font-size:18px;
        }
        .container-fluid {
            background-image: repeating-linear-gradient(#fff, #fff, #fff);
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="col-md-10 container" runat=server style="margin-top:70px;">
        <div class="nav nav-tabs" id="nav-tab" role="tablist">
            <a class="nav-item nav-link active" id="nav-question-btn" data-toggle="tab" href="#nav-question">คำถาม</a>
            <a class="nav-item nav-link" id="nav-reward-btn" data-toggle="tab" href="#nav-reward">ของรางวัล</a>
            <a class="nav-item nav-link justify-content-end" href="report.aspx">Report</a>
        </div>

        <br />
        <div class="tab-content" id="nav-tabContent">
            <!-- คำถาม -->
            <div class="tab-pane fade show active" id="nav-question" role="tabpanel">
                <div class="table-responsesive" style="overflow: scroll;overflow-y: auto;overflow-x: hidden;height: 500px;">
                    <asp:GridView CssClass="table table-striped table-dark" ID="QuestionGridView" runat="server" AutoGenerateColumns ="false" DataKeyNames="QID" 
                        OnRowCancelingEdit="QuestionGridView_RowCancelingEdit"
                        OnRowEditing="QuestionGridView_RowEditing" 
                        OnRowUpdating="QuestionGridView_RowUpdating" >
                        <Columns>
                            <%--คำถาม--%>
                            <asp:TemplateField HeaderText = "คำถาม" HeaderStyle-Width="400px">
                                <ItemTemplate>
                                    <asp:Label ID="QText" runat="server" Text='<%# Eval("QText") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--คำแนะนำ--%>
                            <asp:TemplateField HeaderText = "คำแนะนำ" HeaderStyle-Width="550px">
                                <ItemTemplate>
                                    <asp:Label ID="QRecommend" runat="server" Text='<%# Eval("QRecommend") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--สาขา--%>
                            <asp:TemplateField HeaderText = "สาขา"  HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="QServiceName" runat="server" Text='<%# Eval("QServiceName") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="btn-group">
                                        <asp:DropDownList ID="ServiceEdit" runat="server" CssClass="form-control" >
                                            <asp:ListItem Text="สาขาหน้าปรินส์" Value='40130201' />
                                            <asp:ListItem Text="สาขาจอมทอง" Value='40130202' />
                                            <asp:ListItem Text="สาขาสันป่าตอง" Value='40130203' />
                                            <asp:ListItem Text="สาขาดอนจั่น"  Value='40130204' />
                                            <asp:ListItem Text="สาขาสันทราย" Value='40130205' />
                                            <asp:ListItem Text="ทุกสาขา" Value='99999999' />
                                        </asp:DropDownList>
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                            <%--แก้ไข--%>
                            <asp:TemplateField HeaderText = "แก้ไข">
                                <ItemTemplate>
                                    <asp:Button ID="EditBtn" runat="server" CssClass="btn btn-raised btn-sm btn-info" Text="----Edit----" CommandName="Edit" /> 
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="btn-group">
                                        <asp:Button ID="SaveBtn" runat="server" CssClass="btn btn-raised btn-sm btn-success" CommandName="Update" Text="Save" />
                                        <asp:Button ID="CancelBtn" runat="server" CssClass="btn btn-raised btn-sm btn-warning" CommandName="CANCEL" Text="Cancel" />
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div> 

            <!-- รางวัล -->
            <div class="tab-pane" id="nav-reward" role="tabpanel">
                <div class="table-responsesive" style="overflow: scroll; overflow-y: auto; overflow-x: hidden; height: 500px;">
                    <asp:GridView ID="RewardGridView" CssClass="table table-striped table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="RID" 
                            OnRowCancelingEdit="RewardGridView_RowCancelingEdit" 
                            OnRowEditing="RewardGridView_RowEditing" 
                            OnRowUpdating="RewardGridView_RowUpdating">
                        <Columns>
                            <%--ชื่อของรางวัล--%>
                            <asp:TemplateField HeaderText = "ของรางวัล" HeaderStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="RName" runat="server" Text='<%# Eval("RName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--จำนวน--%>
                            <asp:TemplateField HeaderText = "จำนวน" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="Rtotal" runat="server" Text='<%# Eval("Rtotal") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass ="form-control form-control-sm" style="width:100px;" Text ='<%# Eval("Rtotal") %>' ID="RtotalTxt" runat="server" autocomplete="off" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                            <%--รูป--%>
                            <asp:TemplateField HeaderText = "รูป" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl=<%# "/img/"+Eval("img") %> Width ="80px" Height ="80px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <%--แก้ไข--%>
                            <asp:TemplateField HeaderText = "แก้ไข" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="RewardEditBtn" runat="server" CssClass="btn btn-raised btn-sm btn-info" Text="----Edit----" CommandName="Edit" /> 
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="btn-group">
                                        <asp:Button ID="RewardSaveBtn" runat="server" CssClass="btn btn-raised btn-sm btn-success" CommandName="Update" Text="Save" />
                                        <asp:Button ID="RewardCancelBtn" runat="server" CssClass="btn btn-raised btn-sm btn-warning" CommandName="CANCEL" Text="Cancel" />
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div> 
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>