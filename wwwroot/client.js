"use strict";

window.onload = function() {
    // generate table html for leaderboard
    for (let i = 1; i <= 10; i++) {
        document.getElementById('tbody').innerHTML += `<tr><th class="rank">${i}.</th><td class="name"></td><td class="date"></td><td class="score"></td></tr>`;
    }
    getData('api/score/top/10');
}

// get initial data from db using AJAX
function getData(url) {
    fetch(url)
        .then(response => response.json())
        .then(scores => {
            showTable(scores);
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        });
}

function showTable(scores) {
    const rows = document.querySelectorAll('tbody tr');
    for (let i = 0; i < scores.length; i++){
        const cols = rows[i].querySelectorAll('td');
        cols[0].innerHTML = scores[i].name;
        cols[1].innerHTML = formatDate(new Date(scores[i].date));
        cols[2].innerHTML = scores[i].total;
        rows[i].id = scores[i].id;      
    }
    for (let i = scores.length; i < rows.length; i++){
        rows[i].querySelectorAll('td').forEach(col => { col.innerHTML = ""; });
    }
}

function formatDate(date) {
    const y = date.getFullYear();
    const m = date.getMonth() + 1;
    const d = date.getDate();
    return y + "." + (m < 10 ? "0" + m : m) + "." + (d < 10 ? "0" + d : d);
}

//------------------------- signalR -----------------------------------------
var connection = new signalR.HubConnectionBuilder().withUrl("/pymonHub").build();

// initialize signalR connection
connection.start().then(function () {
    console.log('connection started');
});

// upon receipt of add message, refresh table rows
connection.on("ReceiveAddMessage", function (scores) {
    showTable(scores);
    const element = document.getElementById('container');
    element.classList.add('highlight-add');
    element.addEventListener('transitionend', () => {
        element.classList.remove('highlight-add');
    });
});

connection.on("ReceiveDeleteMessage", function (scores) {
    showTable(scores);
    const element = document.getElementById('container');
    element.classList.add('highlight-delete');
    element.addEventListener('transitionend', () => {
        element.classList.remove('highlight-delete');
    });
});

connection.on("ReceiveDeleteAllMessage", function (scores) {
    showTable(scores);
    const element = document.getElementById('container');
    element.classList.add('highlight-delete');
    element.addEventListener('transitionend', () => {
        element.classList.remove('highlight-delete');
    });
});
