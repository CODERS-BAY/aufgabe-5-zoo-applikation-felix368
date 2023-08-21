import {useState} from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import {useNavigate} from 'react-router-dom';
import './App.css'
import CategorCard from "./CategoryCard.jsx"

function App() {

    const navigate = useNavigate();
    return (
        <>
            <div className={"startCard"} onClick={()=>navigate("/TierPfleger")}>
                <CategorCard   title={"TierPfleger"} imagePath={".\\lemurs.jpg"}/>
            </div>
            <div className={"startCard"} onClick={()=>navigate("/Kassierer")}>
                <CategorCard   title={"Kassa"} imagePath={".\\shop.jpg"}/>
            </div>
            <div className={"startCard"} onClick={()=>navigate("/Besucher")}>
                <CategorCard  title={"Besucher"} imagePath={".\\family.jpg"}/>
            </div>

        </>
    )
}

export default App
