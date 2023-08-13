import * as React from 'react';
import {useState} from "react";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import PflegerAnimalList from "./PflegerAnimalList.jsx";
import PlegerSelectDialog from "../PflegerSelectDialog.jsx";

export default function Tierpfleger() {

    const [PflegerId, setPflegerId] = useState("");
    const [showTable, setShowTable] = useState(false);
    const [showDialog, setShowDialog] = useState(false);
    const [animalData, setAnimalData] = useState();
    

    async function showAnimals(){

        console.log(`http://localhost:5207/api/Tierpfleger/getAnimal/${PflegerId}`)
        const data = fetch(`http://localhost:5207/api/Tierpfleger/getAnimal/${PflegerId}`)
        return (await data).json();


    }


    return (
        <>
            <h1>Tierpfleger</h1>
            <TextField fullWidth onChange={(e)=>{ setPflegerId(e.target.value)}} label="Pfleger ID" id="fullWidth" />
            <Button className={"searchButton"} variant="contained" onClick={async () => {
                const data = await showAnimals()
                console.log(data)
                setAnimalData(data)
                setShowTable(true)

            }}>Suchen</Button>

            {showTable && <PflegerAnimalList value={animalData} onTableRowClick={(id) => {

                setShowDialog(true)
            }}/>}

            {showDialog && <PlegerSelectDialog/>}
        </>
        
    )
}



