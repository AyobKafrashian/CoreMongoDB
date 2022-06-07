//import { signalR } from "../lib/microsoft/signalr/dist/browser/signalr";


$(() => {

    LoadProdData();

    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();

    connection.on("LoadProdData", function () {
        LoadProdData();
    })


    LoadProdData();

    function LoadProdData() {

        var tr = '';
        $.ajax({
            url: '/Employees/GetEmployeeData',
            method: 'GET',
            success: (res) => {
                $.each(res, (k, v) => {
                    tr += `<tr>
                            <td>${v.Year}</td>
                            <td>${v.Name}</td>
                            <td>${v.Description}</td>
                            <td>${v.CreateDate}</td>
                           <td>
                            <a href="/Books/Edit/${v.Id}" class="btn btn-warning">Edit</a>
                          </td>
                       </tr>`
                })

                $("#dataModel").html(tr);

            },
            error: (error) => {
                console.log(error);
            }
        });
    }



})