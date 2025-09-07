$('#btnAdd').click(function () {
    $('#PatientMadal').modal('show');
})

/*<--Add function-->*/
function Add()
{
    debugger
    var objData = {
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        Contact: $('#Contact').val(),
        Email: $('#Email').val(),
        Gender: document.querySelector('input[name="Gender"]:checked').value,
        MedicalConditions: document.querySelector('input[name=MedicalConditions]:checked').value,
        Symptoms: document.querySelector('input[name=Symptoms]:checked').value,
        Address: $('#Address').val(),
        City : document.getElementById("City").value,
        Pincode: $('#Pincode').val(),
        Note:$('#Note').val(),
    };
    $.ajax({
        url: '/Patient/AddPatient',
        type: 'Post',
        data: objData,
        contenttype: 'applicastion/xxx-www-fore-urlencoded;charset=utf-8',
        datatype: 'json',
        success: function () {
            alert('Data Saved');
        },
        error: function () {
            alert('data not saved');
        }
    });
}