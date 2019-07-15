$("input[id*=atxtQty]").each(function(i, o){
    $(this).parents("tr").find("input[id*=atxtShareQty]").val( Math.floor( (o.value * 1) * 0.1 ) )
})