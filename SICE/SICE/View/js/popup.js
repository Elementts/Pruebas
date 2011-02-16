$(function(){ //llamada tras la carga de la página
    var enlace =$("a.popup").click(function(){  //indicamos que al hacer click en cualquier elemento "a" que tenga la clase "claseDelEnlace" ejecute la siguiente función
        var destino = $(this).attr("href");
		var anchoventana = 550;
		var altoventana = 400;
        $.ajax({
				 type: "GET",
				 url: destino,
				 success: function(data){ //indicamos la función que se ejecutará al recibir los datos en la variable data exitosamente
                                 //limitamos el contenido del documento a lo que está dentro de la etiqueta body
                                 var ini = data.indexOf("<body");
                                  if (ini>=0){
		                         ini = data.indexOf(">", ini)+1;
                                      var fin = data.indexOf("</body");
                                      fin = fin-ini;
                                      var datos= data.substr(ini, fin);
                                  }else{
                                      var datos = data;
                                 }
                                 //si el contenido del documento tiene la etiqueta title, la extraemos para utilizarla como titulo de la ventana
								  ini = 0;
                                  ini = data.indexOf("<title");
                                  if (ini>=0){
		                              ini = data.indexOf(">", ini)+1;
								      fin = 0;
                                      fin = data.indexOf("</title");
                                      fin = fin-ini;
                                      var titulo= data.substr(ini, fin);
                                  }else{
                                      var titulo = "Ventana Emergente";
                                 }
                                 $("body").append('<div class="ventana">'+datos+'</div>'); //adjuntamos los datos recibidos en una capa con la clase "ventana" al final del documento
                                 $("div.ventana").dialog({  //indicamos que las capas con la clase "ventana" son ventanas de dialogo
                                          closeText: 'Cerrar', 
                                          title: titulo,
										  height: altoventana,
										  width: anchoventana,
                                          close: function(){ //indicamos la función que se ejecutará al cerrarse la ventana
                                                  $(this).remove(); //borramos la capa
                                          }
                                  });
                            }
        });
		return false;
    });
});
