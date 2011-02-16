$(function () {
	// Dock initialize
	$('#dock').Fisheye(
		{
			maxWidth: 50,
			items: 'a',
			itemsText: 'span',
			container: '.dock-container',
			itemWidth: 70,
			proximity: 30,
			alignment : 'left',
			valign: 'bottom',
			halign : 'center'
		}
	);
});

