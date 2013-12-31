function animations() {
	$("#header").show("slow", function() {
		$("#subtitle").show("slow", function() {
			$("#video_col").fadeIn("fast");
			$("#opensource").fadeIn("slow");
		});
	});
}

function init() {
	$("#subtitle").hide();
	$("#video_col").hide();
	$("#opensource").hide();
	$("#header").hide();
	
	setTimeout("animations()", 200);
}

//$(document).ready(init);
