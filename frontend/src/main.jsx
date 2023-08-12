import React from 'react'
import ReactDOM from 'react-dom/client'
import {
    createBrowserRouter,
    RouterProvider,
} from 'react-router-dom';
import App from './App.jsx'
import Tierpfleger from "./Tierpfleger.jsx";
import Kassierer from "./Kassierer.jsx";
import Besucher from "./Besucher.jsx";
import CategorCard from "./CategoryCard.jsx";
import './index.css'

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
    },
    {
        path: "/TierPfleger",
        element: <Tierpfleger />,
    },
    {
        path: "/Kassierer",
        element: <Kassierer/>,
    },
    {
        path: "/Besucher",
        element: <Besucher />,
    },
    {
        path: "/Test",
        element: <CategorCard />,
    },
    
    
]);


ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>,
);
