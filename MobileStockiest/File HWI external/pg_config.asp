<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">

<style type="text/css">
h1 {text-align: left}
table {text-align: left}
tr {text-align: left}

</style>

<!--#Include File=dbcon/opendb.asp-->
<%
Response.Buffer=True
Response.CacheControl = "no-cache"
Response.AddHeader "Pragma", "no-cache"
Response.Expires = -1
Response.ExpiresAbsolute = Now()-1

Server.ScriptTimeout = 9000000
Session.Timeout = 45

dim myico
dim judulwebnya
dim title_web

title_web = "PT. HEALTH WEALTH INTERNATIONAL :: "
judulwebnya = "PT. HEALTH WEALTH INTERNATIONAL :: "
session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
myico = "icon.ico"

'dim bgimage
'bgimage = "images/background.jpg"

dim bgimage

tatanggalan = day(date())
					if len(tatanggalan) = 1 then
						tatanggalan = "0"+cstr(tatanggalan)
					else
						tatanggalan = tatanggalan
					end if		
wulandari =  month(date())
					if len(wulandari) = 1 then
						wulandari = "0"+cstr(wulandari)
					else
						wulandari = wulandari
					end if		

taundari = year(date()) 

tanggalnateh = cstr(taundari)+cstr(wulandari)+cstr(tatanggalan)
tanggalnateh = clng(tanggalnateh)

if tanggalnateh >= 20150618 and tanggalnateh <= 20150720 then
bgimage = "images/ramadhan.jpg"
else
bgimage = "images/background.jpg"
end if


if tanggalnateh >= 20130805 and tanggalnateh <= 20130810 then
gb1 = "lebaran.jpg"
else
gb1 = "image (1).jpg"
end if

dim dcpusat
dim mspusat

dcpusat = "B-000"
session.contents("dcPusat") = "B-000"

mspusat = "B-000"
session.contents("msPusat") = "B-000"

dim dcH0
dcHO = "B-000"
session.contents("dcHO") = "B-000"

dim msH0
msHO = "B-000"
session.contents("msHO") = "B-000"

dim gdho
gdho = "HO"
session.contents("gdHO") = "HO"

dim min_order_ms
dim min_order_nc
dim min_order_mc
dim min_perdana_mc
min_order_ms = 2500000 ' minimal jumlah order regional DC untuk mendapatkan potongan
min_order_nc = 1000000 ' minimal jumlah order distribution center untuk mendapatkan potongan
min_order_mc = 1000000 ' minimal jumlah order mobile center untuk mendapatkan potongan
min_perdana_mc = 2500000 ' minimal jumlah order perdana mobile center untuk mendapatkan potongan

'dim noawal_pakai
'dim noakhir_pakai
'noawal_pakai = 2000000
'noakhir_pakai = 2001000
%>


<SCRIPT>
// Before you reuse this script you may want to have your head examined
// 
// Copyright 1999 InsideDHTML.com, LLC.  

function doBlink() {
  // Blink, Blink, Blink...
  var blink = document.all.tags("BLINK")
  for (var i=0; i < blink.length; i++)
    blink[i].style.visibility = blink[i].style.visibility == "" ? "hidden" : "" 
}

function startBlink() {
  // Make sure it is IE4
  if (document.all)
    setInterval("doBlink()",1000)
}
window.onload = startBlink;
</SCRIPT>

<script type="text/javascript">
function enlarge(image) {
var i = new Image();
i.src = image;
var x = i.width;
var y = i.height;
// window.status for degugging:
window.status = image + " = " + x + " x " + y + " pixels";
var z = "scrollbars=no,width=" + (x+20) + ",height=" + (y+20);
window.open(image,"image",z);
}
</script>

<script type="text/javascript">
function init() {
  if (!document.getElementById) return
  var imgOriginSrc;
  var imgTemp = new Array();
  var imgarr = document.getElementsByTagName('img');
  for (var i = 0; i < imgarr.length; i++) {
    if (imgarr[i].getAttribute('hsrc')) {
        imgTemp[i] = new Image();
        imgTemp[i].src = imgarr[i].getAttribute('hsrc');
        imgarr[i].onmouseover = function() {
            imgOriginSrc = this.getAttribute('src');
            this.setAttribute('src',this.getAttribute('hsrc'))
        }
        imgarr[i].onmouseout = function() {
            this.setAttribute('src',imgOriginSrc)
        }
    }
  }
}
onload=init;
</script>

<script type="text/javascript">
var weekdaystxt=["", "", "", "", "", "", ""]

function showLocalTime(container, servermode, offsetMinutes, displayversion){
if (!document.getElementById || !document.getElementById(container)) return
this.container=document.getElementById(container)
this.displayversion=displayversion
var servertimestring=(servermode=="server-php")? '<? print date("F d, Y H:i:s", time())?>' : (servermode=="server-ssi")? '<!--#config timefmt="%B %d, %Y %H:%M:%S"--><!--#echo var="DATE_LOCAL" -->' : '<%= Now() %>'
this.localtime=this.serverdate=new Date(servertimestring)
this.localtime.setTime(this.serverdate.getTime()+offsetMinutes*60*1000) //add user offset to server time
this.updateTime()
this.updateContainer()
}

showLocalTime.prototype.updateTime=function(){
var thisobj=this
this.localtime.setSeconds(this.localtime.getSeconds()+1)
setTimeout(function(){thisobj.updateTime()}, 1000) //update time every second
}

showLocalTime.prototype.updateContainer=function(){
var thisobj=this
if (this.displayversion=="long")
this.container.innerHTML=this.localtime.toLocaleString()
else{
var hour=this.localtime.getHours()
var minutes=this.localtime.getMinutes()
var seconds=this.localtime.getSeconds()
var ampm=(hour>=12)? "PM" : "AM"
var dayofweek=weekdaystxt[this.localtime.getDay()]
this.container.innerHTML=formatField(hour, 1)+":"+formatField(minutes)+":"+formatField(seconds)+" "+ampm+" "+dayofweek+""
}
setTimeout(function(){thisobj.updateContainer()}, 1000) //update container every second
}

function formatField(num, isHour){
if (typeof isHour!="undefined"){ //if this is the hour field
var hour=(num>12)? num-12 : num
return (hour==0)? 12 : hour
}
return (num<=9)? "0"+num : num//if this is minute or sec field
}
</script>

<script>
function submitonce(theform){
//if IE 4+ or NS 6+
if (document.all||document.getElementById){
//screen thru every element in the form, and hunt down "submit" and "reset"
for (i=0;i<theform.length;i++){
var tempobj=theform.elements[i]
if(tempobj.type.toLowerCase()=="submit"||tempobj.type.toLowerCase()=="reset")
//disable em
tempobj.disabled=true
}
}
}
</script>

<style type="text/css">
#dhtmltooltip{
position: absolute;
left: -300px;
width: 250px;
border: 1px solid black;
padding: 2px;
background-color: lightyellow;
visibility: hidden;
z-index: 100;
/*Remove below line to remove shadow. Below line should always appear last within this CSS*/
filter: progid:DXImageTransform.Microsoft.Shadow(color=gray,direction=135);
}

#dhtmlpointer{
position:absolute;
left: -300px;
z-index: 101;
visibility: hidden;
}
</style>

<script language="javascript">
var win = null;
function NewWindow(mypage,myname,w,h,scroll){
LeftPosition = (screen.width) ? (screen.width-w)/2 : 0;
TopPosition = (screen.height) ? (screen.height-h)/2 : 0;
settings =
'height='+h+',width='+w+',top='+TopPosition+',left='+LeftPosition+',scrollbars='+scroll+',resizable'
win = window.open(mypage,myname,settings)
}
</script>

<%
Function SafeSQL(sInput)
  TempString = sInput
  sBadChars=array("SELECT", "HAVING", "ALTER", "DROP", "ORDER", "GROUP BY", "INSERT", "@@VERSION", "VERSION()", "AND 1", "INFORMATION_SCHEMA.TABLES","GROUP_CONCAT", "DELETE", "CONCAT_WS", "--", "*", "xp_", "#", "%", "&", "'", ";", "`", "|", "$") 
  For iCounter = 0 to uBound(sBadChars)
    TempString = replace(TempString,sBadChars(iCounter),"")
  Next
  SafeSQL = TempString
End function

'*********************************************
'***  	   Decode HTML encoding		 *****
'*********************************************

'Decode encoded strings
Private Function decodeString(ByVal strInputEntry)

	'Decode HTML character entities

	strInputEntry = Replace(strInputEntry, "&#097;", "a", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#098;", "b", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#099;", "c", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#100;", "d", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#101;", "e", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#102;", "f", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#103;", "g", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#104;", "h", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#105;", "i", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#106;", "j", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#107;", "k", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#108;", "l", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#109;", "m", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#110;", "n", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#111;", "o", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#112;", "p", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#113;", "q", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#114;", "r", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#115;", "s", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#116;", "t", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#117;", "u", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#118;", "v", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#119;", "w", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#120;", "x", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#121;", "y", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#122;", "z", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#065;", "A", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#066;", "B", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#067;", "C", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#068;", "D", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#069;", "E", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#070;", "F", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#071;", "G", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#072;", "H", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#073;", "I", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#074;", "J", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#075;", "K", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#076;", "L", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#077;", "M", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#078;", "N", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#079;", "O", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#080;", "P", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#081;", "Q", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#082;", "R", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#083;", "S", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#084;", "T", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#085;", "U", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#086;", "V", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#087;", "W", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#088;", "X", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#089;", "Y", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#090;", "Z", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#048;", "0", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#049;", "1", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#050;", "2", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#051;", "3", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#052;", "4", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#053;", "5", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#054;", "6", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#055;", "7", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#056;", "8", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#057;", "9", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#061;", "=", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&lt;", "<", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&gt;", ">", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&amp;", "&", 1, -1, 0)
	strInputEntry = Replace(strInputEntry, "&#146;", "'", 1, -1, 1)

	'Return
	decodeString = strInputEntry
End Function
%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
<script type="text/javascript">
var offsetfromcursorX=12 //Customize x offset of tooltip
var offsetfromcursorY=10 //Customize y offset of tooltip

var offsetdivfrompointerX=10 //Customize x offset of tooltip DIV relative to pointer image
var offsetdivfrompointerY=14 //Customize y offset of tooltip DIV relative to pointer image. Tip: Set it to (height_of_pointer_image-1).

document.write('<div id="dhtmltooltip"></div>') //write out tooltip DIV
document.write('<img id="dhtmlpointer" src="images/arrow2.gif">') //write out pointer image

var ie=document.all
var ns6=document.getElementById && !document.all
var enabletip=false
if (ie||ns6)
var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""

var pointerobj=document.all? document.all["dhtmlpointer"] : document.getElementById? document.getElementById("dhtmlpointer") : ""

function ietruebody(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function ddrivetip(thetext, thewidth, thecolor){
if (ns6||ie){
if (typeof thewidth!="undefined") tipobj.style.width=thewidth+"px"
if (typeof thecolor!="undefined" && thecolor!="") tipobj.style.backgroundColor=thecolor
tipobj.innerHTML=thetext
enabletip=true
return false
}
}

function positiontip(e){
if (enabletip){
var nondefaultpos=false
var curX=(ns6)?e.pageX : event.clientX+ietruebody().scrollLeft;
var curY=(ns6)?e.pageY : event.clientY+ietruebody().scrollTop;
//Find out how close the mouse is to the corner of the window
var winwidth=ie&&!window.opera? ietruebody().clientWidth : window.innerWidth-20
var winheight=ie&&!window.opera? ietruebody().clientHeight : window.innerHeight-20

var rightedge=ie&&!window.opera? winwidth-event.clientX-offsetfromcursorX : winwidth-e.clientX-offsetfromcursorX
var bottomedge=ie&&!window.opera? winheight-event.clientY-offsetfromcursorY : winheight-e.clientY-offsetfromcursorY

var leftedge=(offsetfromcursorX<0)? offsetfromcursorX*(-1) : -1000

//if the horizontal distance isn't enough to accomodate the width of the context menu
if (rightedge<tipobj.offsetWidth){
//move the horizontal position of the menu to the left by it's width
tipobj.style.left=curX-tipobj.offsetWidth+"px"
nondefaultpos=true
}
else if (curX<leftedge)
tipobj.style.left="5px"
else{
//position the horizontal position of the menu where the mouse is positioned
tipobj.style.left=curX+offsetfromcursorX-offsetdivfrompointerX+"px"
pointerobj.style.left=curX+offsetfromcursorX+"px"
}

//same concept with the vertical position
if (bottomedge<tipobj.offsetHeight){
tipobj.style.top=curY-tipobj.offsetHeight-offsetfromcursorY+"px"
nondefaultpos=true
}
else{
tipobj.style.top=curY+offsetfromcursorY+offsetdivfrompointerY+"px"
pointerobj.style.top=curY+offsetfromcursorY+"px"
}
tipobj.style.visibility="visible"
if (!nondefaultpos)
pointerobj.style.visibility="visible"
else
pointerobj.style.visibility="hidden"
}
}

function hideddrivetip(){
if (ns6||ie){
enabletip=false
tipobj.style.visibility="hidden"
pointerobj.style.visibility="hidden"
tipobj.style.left="-1000px"
tipobj.style.backgroundColor=''
tipobj.style.width=''
}
}

document.onmousemove=positiontip

</script>			
		</td>
	</tr>
</table>
