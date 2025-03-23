import { useState } from "react";
import './App.css'
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import UserForm from "./Pages/UserForm"
import ActividadesList from "./Pages/ActividadesList"
import NavBar from "./Pages/NavBar"
import Home from "./Pages/Home"

export default function App() {
  return (
  <Router>
  <NavBar />
  <Routes>
  <Route  path="/userform" element={<UserForm />}></Route>
  <Route  path="/" element={<Home />}></Route>
  <Route  path="/actividadeslist" element={<ActividadesList />}></Route>
  <Route  path="/navbar" element={<NavBar />}></Route>
  </Routes>
  </Router>
  )
  }

 