import { useEffect, useState } from "react";
import apiClient from "../services/api-client";


export interface Employee {
  id: number;
  email: string;
  phone: string;
  firstName: string;
  lastName: string;
  experience: number;
  imagePath: string;
  companyId: number;
  departmentId: number;
  positionId: number;
  discProfileId: number;
}

const useEmployees = () => {
    const [employees, setEmployees] = useState<Employee[]>([]);
    const [error, setError] = useState("");

     useEffect(() => {
        const controller = new AbortController();

        apiClient
          .get<Employee[]>("/employees")
          .then((res) => setEmployees(res.data))
          .catch((err) => setError(err.message));

          return () => controller.abort();//what is this
      }, []);
    return { employees, error };
}

export default useEmployees;