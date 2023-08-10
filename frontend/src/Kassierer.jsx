import * as React from 'react';
import ButtonGroup from '@mui/material/ButtonGroup';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import {useState} from "react";


export default function Kassierer() {

    const [adultCount, setAdultCount] = useState(0);
    const [childCount, setChild] = useState(0);

    function buyTicket(){

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({"adult":3, "child":0})
        };
        fetch('http://localhost:5207/api/BuyTicket', requestOptions)
            .then(response => response.json())
            .then(data => console.log(data));
    }
    
    return (
        <>
            <h1>Kassierer</h1>
            <br/>
            <h2>Erwachsene {adultCount}</h2>
            <ButtonGroup
                disableElevation
                variant="contained"
                aria-label="Disabled elevation buttons"
            >
                <Button onClick={()=>{adultCount !==0 && setAdultCount(adultCount-1)}}>-</Button>
                <Button onClick={()=>{setAdultCount(adultCount+1)}}>+</Button>
            </ButtonGroup>
            <br/>
            <h2>Kinder {childCount}</h2>
            <ButtonGroup
                disableElevation
                variant="contained"
                aria-label="Disabled elevation buttons"
            >
                <Button onClick={()=>{childCount !==0 && setChild(childCount-1)}}>-</Button>
                <Button onClick={()=>{setChild(childCount+1)}}>+</Button>
            </ButtonGroup>
            
            <br/>
            <br/>
            <Button onClick={async ()=>{await buyTicket()}} variant="contained">Bestellen</Button>
            
        </>
    )
    
    
    
}




    