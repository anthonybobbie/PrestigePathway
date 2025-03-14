import { createContext, useState, useEffect } from "react";

// create state { isAuthenticated, setIsAuthenticated }

interface AuthProviderProps {
  children: React.ReactNode;
}
const state: any = null;

export const AuthContext = createContext({ ...state });

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  // Check if user is authenticated from cookies
  useEffect(() => {
    const token = document.cookie
      .split("; ")
      .find((row) => row.startsWith("authToken="));
    setIsAuthenticated(!!token);
  }, []);

  return (
    <AuthContext.Provider value={{ isAuthenticated, setIsAuthenticated }}>
      {children}
    </AuthContext.Provider>
  );
};
