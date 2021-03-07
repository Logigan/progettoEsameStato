<%@ Page Title="" Language="C#" MasterPageFile="~/pagMaster.Master" AutoEventWireup="true" CodeBehind="registrazione.aspx.cs" Inherits="EsameStato.registrazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphRegistrazione" runat="server">
        <div class="banner">
          <h1>Segreteria</h1>
        </div>
        <p>Runner Information</p>
        <div class="item">
          <label for="name">Name<span>*</span></label>
          <input id="name" type="text" name="name" required/>
        </div>
        <div class="item">
          <label for="email">Email Address<span>*</span></label>
          <input id="email" type="email" name="email" required/>
        </div>
        <div class="item">
          <label for="address">Address<span>*</span></label>
          <input id="address" type="address" name="address" required/>
        </div>
        <div class="item">
          <label for="city">City<span>*</span></label>
          <input id="city" type="text" name="city" required/>
        </div>
        <div class="item">
          <label for="state">State<span>*</span></label>
          <input id="state" type="text" name="state" required/>
        </div>
        <div class="item">
          <label for="zip">Zip<span>*</span></label>
          <input id="zip" type="text" name="zip" required/>
        </div>
        <div class="item">
          <label for="phone">Phone<span>*</span></label>
          <input id="phone" type="number" name="phone" required/>
        </div>
        <div class="item">
          <label for="bdate">Date of Birth<span>*</span></label>
          <input id="bdate" type="date" name="bdate" required/>
          <i class="fas fa-calendar-alt"></i>
        </div>
        <div class="question">
          <label>Gender</label>
          <div class="question-answer">
            <div>
              <input type="radio" value="none" id="radio_1" name="gender"/>
              <label for="radio_1" class="radio"><span>Male</span></label>
            </div>
            <div>
              <input  type="radio" value="none" id="radio_2" name="gender"/>
              <label for="radio_2" class="radio"><span>Female</span></label>
            </div>
          </div>
        </div>
        <div class="item">
          <p>T-Shirt Size</p>
          <select>
            <option selected value="" disabled selected></option>
            <option value="course-type" >Small</option>
            <option value="short-courses">Medium</option>
            <option value="featured-courses">Large</option>
            <option value="undergraduate">Extra Large</option>
          </select>
        </div>
        <div class="question">
          <label>Choose Race</label>
          <div class="question-answer">
            <div>
              <input type="radio" value="none" id="radio_3" name="race"/>
              <label for="radio_3" class="radio"><span>5k - $25</span></label>
            </div>
            <div>
              <input  type="radio" value="none" id="radio_4" name="race"/>
              <label for="radio_4" class="radio"><span>10K - $25</span></label>
            </div>
          </div>
        </div>
        <div class="btn-block">
          <button type="submit" href="/">SUBMIT</button>
        </div>
</asp:Content>
