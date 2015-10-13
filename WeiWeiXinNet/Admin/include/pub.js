function onTab(num) {
	var obj=document.getElementById("tab");
	obj.className = "on"+num;
}

function getoffset(e) {
	var l = e.offsetLeft;
	var t = e.offsetTop;
	while (e = e.offsetParent) {
		l += e.offsetLeft;
		t += e.offsetTop;
	}
	var rec = new Array(1);
	rec[0] = l;
	rec[1] = t;
	return rec;
}
function viewImg(obj) {
	var imgBox = document.getElementById("imgBox");
	var rec = getoffset(obj);
	imgBox.style.left = rec[0] - 200 + "px";
	imgBox.style.top = rec[1] - 93 + "px";
	imgBox.style.display = "block";
}
function hiddenImg(obj) {
	var imgBox = document.getElementById("imgBox");
	imgBox.style.display = "none";
}