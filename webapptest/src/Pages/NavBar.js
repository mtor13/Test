import React, { useState} from 'react'
import { Link } from 'react-router-dom'
import './Styles/NavBar2.css';

const NavBar = () => {
const [ show, setShow ] = useState(false)
function showSwitch() {
return setShow(!show)
}
return (

 <div className='navbar'>  

 
      <nav className="navbar">
  <div className="navbar-left">    
  </div>
  <div className="navbar-center">
    <ul className="nav-links">      
      <li>
        <a href="/userform">Usuarios</a>
      </li>
      <li>
        <a href="/actividadeslist">Actividades</a>
      </li>
    </ul>
  </div>  
</nav>

 </div>
 )
 }
 export default NavBar