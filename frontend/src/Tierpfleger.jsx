import * as React from 'react';
import {useState} from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import PflegerAnimalList from "./PflegerAnimalList.jsx";
import PlegerSelectDialog from "./PflegerSelectDialog.jsx";
import SuccessSnackbar from "./SuccessSnackbar.jsx";

export default function Tierpfleger() {

    const [PflegerId, setPflegerId] = useState("");
    const [showTable, setShowTable] = useState(false);
    const [showDialog, setShowDialog] = useState(false);
    const [snackBar, setsnackBar] = useState(false);
    const [animalData, setAnimalData] = useState();
    const [selectedAnimalData ,setSelectedAnimalData ] = useState();
    let timeout;
    
    async function okDialog(id,columnName,newData){
        
        console.log(columnName)
        console.log(newData)
        
        const data = await fetch(`http://localhost:5207/api/Tierpfleger/updateAnimal/${id}&${columnName}&${newData}`)
        
        if(data.status == 202){
            showSnackbar();
        }
        
        setShowDialog(false)
    }
    
    
    

    async function showAnimals(){

        
        const data = await fetch(`http://localhost:5207/api/Tierpfleger/getAnimal/${PflegerId}`)
        return data.json();


    }



    async function showSnackbar(){
        function closeSnackbar(){
            setsnackBar(false);
        }

        setsnackBar(true);
        if(timeout){
            clearTimeout(timeout);
            timeout=null;
        }

        timeout = setTimeout(closeSnackbar, 3000);

        

    }
    
    
    
    
    


    return (
        <>
            <h1>Tierpfleger</h1>
            <TextField fullWidth onChange={(e)=>{ setPflegerId(e.target.value)}} value={PflegerId} label="Pfleger ID" id="fullWidth" />
            <Button className={"searchButton"} variant="contained" onClick={async () => {
                const data = await showAnimals()
                setAnimalData(data)
                setShowTable(true)

            }}>Suchen</Button>

            {showTable && <PflegerAnimalList value={animalData} onTableRowClick={(animal) => {

                setShowDialog(true)
                setSelectedAnimalData(animal)
            }}/>}

            {showDialog && <PlegerSelectDialog animal={selectedAnimalData} okClick={(id, columnName, newData)=>{okDialog(id, columnName, newData)}} cancelClick={() =>{setShowDialog(false)}}/>}
            {snackBar && <SuccessSnackbar/>}
        </>
        
    )
}



