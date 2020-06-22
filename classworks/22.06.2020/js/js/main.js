window.onload = function () {
    let my_array=[];

    document.getElementById("btnAdd").onclick=addClick;
    
    function addClick(e) {
        let product={
            image: "",
            name: "",
            price: 0
        };
        e.preventDefault(); //відмінити стандартну поведінку
        product.image=document.getElementById("image").value;
        product.name=document.getElementById("name").value;
        product.price=document.getElementById("price").value;

        //console.log("object product", product);
        addProduct(product);
    }

    function addProduct(product) {
        let productContent = document.getElementById("productContent");
        let row = document.createElement('tr');
        row.innerHTML=`
                    <td>
                        <img width="150"
                            src="${product.image}">
                    </td>
                    <td>${product.name}</td>
                    <td>${product.price} грн.</td>
        `;
        productContent.appendChild(row);
        my_array.push(product);
        console.log("-------product array-------", my_array);
    }
}