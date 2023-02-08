import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";
import { useMemo } from "react";
import { useSelector } from "react-redux";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import { themeSettings } from "theme";
import Layout from "scenes/layout";
import Dashboard from "scenes/dashboard";
import Products from "scenes/products";
import Customers from "scenes/customers";
import Transactions from "scenes/transactions";
import Shop from "scenes/shop";
import Monthly from "scenes/monthly";
import Breakdown from "scenes/breakdown";
import Form from "scenes/form";
import LoginForm from "scenes/login/Login.jsx";
import SignUpForm from "scenes/login/Signup";



function App() {
  const mode = useSelector((state) => state.global.mode);
  const theme = useMemo(() => createTheme(themeSettings(mode)), [mode]);
  return (
    <div className="app">
      <BrowserRouter>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Routes>
            <Route path="/login" element={<LoginForm />} />
            <Route path="/signup" element={<SignUpForm />} />
            <Route path="/" element={<LoginForm />} />
            <Route element={<Layout />}>
              <Route path="/homepage" element={<Navigate to="/dashboard" replace />} />
              <Route path="/dashboard" element={<Dashboard />} />
              <Route path="/stocks" element={<Products />} />
              <Route path="/leaderboard" element={<Customers />} />
              <Route path="/profile" element={<Form />} />
              <Route path="/calendar" element={<Monthly />} />
              <Route path="/transactions" element={<Transactions />} />
              <Route path="/breakdown" element={<Breakdown />} />
              {/* To Add */}
              <Route path="/shop" element={<Shop />} />
              <Route path="/about" element={<Breakdown />} />
            </Route>
          </Routes>
        </ThemeProvider>
      </BrowserRouter>
    </div>
  );
}

export default App;
