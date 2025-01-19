import { Outlet } from 'react-router-dom';
import Header from '../Components/Header';

const RootLayout = () => {
  return (
    <div>
      {/* Header wordt bovenaan weergegeven */}
      <Header />
      
      {/* Hier worden de child-routes weergegeven */}
      <main className="p-4">
        <Outlet />
      </main>
    </div>
  );
};
export default RootLayout;
