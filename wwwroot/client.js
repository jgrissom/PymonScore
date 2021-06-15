"use strict";

window.onload = function() {
    getData('api/score/top/10');
}

// get initial data from db using AJAX
function getData(url) {
    fetch(url)
        .then(response => response.json())
        .then(scores => {
            console.log(scores);
            showTable(scores);
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        });
}

function showTable(scores) {
    const tbody = document.getElementById('tbody');
    let rank = 1;
    scores.forEach(score => {
        tbody.innerHTML += '<tr data-id=' + score.id + '><th>' + rank++ + '.</th><td>' + score.name + '</td><td>' + formatDate(new Date(score.date)) + '</td><td class="score">' + score.total + '</td></tr>';
    }); 
}

function formatDate(date) {
    const y = date.getFullYear();
    const m = date.getMonth() + 1;
    const d = date.getDate();
    return y + "." + (m < 10 ? "0" + m : m) + "." + (d < 10 ? "0" + d : d);
}
