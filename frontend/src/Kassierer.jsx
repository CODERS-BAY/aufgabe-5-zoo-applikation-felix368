import * as React from 'react';
import ButtonGroup from '@mui/material/ButtonGroup';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import SuccessSnackbar from "./SuccessSnackbar.jsx";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';

import {useState} from "react";
import TicketList from "./TicketList.jsx";


export default function Kassierer() {

    const [adultCount, setAdultCount] = useState(0);
    const [childCount, setChild] = useState(0);
    const [snackBar, setsnackBar] = useState(false);
    const [ticketSearchDate, settTicketSearchDate] = useState("");
    let timeout;

    
    
    
    
    
    
    async function buyTicket() {

        const requestOptions = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({"adult": adultCount, "child": childCount}),
        };
        //const data = await fetch('http://localhost:5207/api/BuyTicket', requestOptions)

        return  await new Promise(async(resolve)=>{
            const response = await fetch('http://localhost:5207/api/BuyTicket',requestOptions);
            const data = response.json();
            
            if(response.status==200){
                await showSnackbar();
            }
            resolve(data);
        })
        
    }
    
    
    
    async function getTicketByDate(){
        
        
        
        
        const response = await fetch(`/api/getTickets/${date}`);
        const data = await response.json();
        
        console.log(data)
        
        
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
        
        return ()=>{
            if(timeout){
                clearTimeout(timeout);
                timeout=null;
                
            }
        }
        
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
            <Button onClick={async ()=>{
                const data = await buyTicket()
                
            }} variant="contained">Bestellen</Button>
            {snackBar && <SuccessSnackbar/>}
            
            <div id={"TicketArea"}>

                <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker onChange={(e)=>{
                            //settTicketSearchDate(e.target.value)
                            console.log(e)
                        }} />
                </LocalizationProvider>

                
            </div>
            
        </>
    )
    
}

    