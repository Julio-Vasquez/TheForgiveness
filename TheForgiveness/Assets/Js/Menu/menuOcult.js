function ocult()
{
	var t = document.getElementsByTagName('span');
	for (var i = t.length - 1; i >= 0; i--)
		t[i].style.display= 'none';
	document.getElementsByClassName('left-sidebar')[0].style.width='70px';
	document.getElementsByClassName('page-wrapper')[0].style.marginLeft='70px';
}

function desOcult()
{
	var t = document.getElementsByTagName('span');
	for (var i = t.length - 1; i >= 0; i--)
		t[i].style.display= 'flex';
	document.getElementsByClassName('left-sidebar')[0].style.width='250px';
	document.getElementsByClassName('page-wrapper')[0].style.marginLeft='250px';
}

//falta add el evento al boton, y cuando le de click cambiar el icono-