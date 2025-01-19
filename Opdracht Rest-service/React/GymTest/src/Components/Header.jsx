import { NavLink } from 'react-router-dom';

const Header = () => {
  const headerStyle = {
    backgroundColor: '#3b82f6',
    color: 'white', 
    height: '6rem', 
    display: 'flex', 
    alignItems: 'center', 
    justifyContent: 'space-between', 
    padding: '0 1.5rem', 
    margin: 0, 
  };

  const titleStyle = {
    fontSize: '1.875rem', 
    fontWeight: 200, 
  };

  const navStyle = {
    display: 'flex', 
    gap: '1.5rem', 
  };

  const linkStyle = {
    textDecoration: 'none', 
  };

  const activeLinkStyle = {
    ...linkStyle,
    textDecoration: 'underline', 
    textUnderlineOffset: '8px', 
    fontWeight: 'bold', 
  };

  return (
    <div style={headerStyle}>
      <p style={titleStyle}>Gymtest Reservation Maker</p>
      <div style={navStyle}>
        <NavLink
          to="/"
          style={({ isActive }) => (isActive ? activeLinkStyle : linkStyle)}
        >
          Home
        </NavLink>
      </div>
    </div>
  );
};

export default Header;
