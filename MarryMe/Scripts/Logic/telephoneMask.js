$("#manTel").mask("+(999) 99-999-99-99");


$("#manTel").on("blur", function () {
	var last = $(this).val().substr($(this).val().indexOf("-") + 1);

	if (last.length == 3) {
		var move = $(this).val().substr($(this).val().indexOf("-") - 1, 1);
		var lastfour = move + last;

		var first = $(this).val().substr(0, 9);

		$(this).val(first + '-' + lastfour);
	}
});

$("#womanTel").mask("+(999) 99-999-99-99");


$("#womanTel").on("blur", function () {
	var last = $(this).val().substr($(this).val().indexOf("-") + 1);

	if (last.length == 3) {
		var move = $(this).val().substr($(this).val().indexOf("-") - 1, 1);
		var lastfour = move + last;

		var first = $(this).val().substr(0, 9);

		$(this).val(first + '-' + lastfour);
	}
});