import * as React from 'react';
import TextField from '@mui/material/TextField';
import Button from "@mui/material/Button";
import {useState} from "react";
import AnimalList from "./AnimalList.jsx";
export default function Besucher() {

    const [animalName, setAnimalName] = useState("");
    const [showTable, setShowTable] = useState(false);
    const [animalData, setAnimalData] = useState();

    async function showAnimals(){

        const data = fetch(`http://localhost:5207/api/getAnimal/${animalName}`)
        return (await data).json();
        
    }
    
    
    return (
        <>
            <h1>Besucher</h1>
            <TextField fullWidth onChange={(e)=>{ setAnimalName(e.target.value)}} value={animalName} label="Tier Name" id="fullWidth" />
            <Button className={"searchButton"} variant="contained" onClick={async () => {
                const data = await showAnimals()
                console.log(data)
                setAnimalData(data)
                setShowTable(true)
                
            }}>Suchen</Button>

            {showTable && <AnimalList value={animalData}/>}
        </>
        
    )
}