var encontrados = [];
var naoEncontrados = [];

$(lista).each(function(i, obj){

    var elemento = $("#frmInvMaintain table tbody td").filter(function() {
        return $(this).text().toUpperCase() === obj.Codigo.toUpperCase();
    });
    
    if(elemento.length > 0){
        encontrados.push(obj);
        $(elemento).addClass("encontrado");
        $(elemento).parents("tr").find("input[id*=atxtQty]").val(obj.Qtd);
    } else {
        naoEncontrados.push(obj);
    }



})

$("#frmInvMaintain table tbody tr").each(function(){

    $(this).find("td:eq(0):not(.encontrado)").css("border", "5px red solid");

})

console.log("NAO ENCONTRADOS:");
console.log(naoEncontrados);

