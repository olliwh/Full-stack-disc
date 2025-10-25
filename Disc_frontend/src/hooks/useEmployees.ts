import { useEffect, useState } from "react";
import apiClient from "../services/api-client";
import { CanceledError } from "axios";


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
    const [isLoading, setIsLoading] = useState(false);


     useEffect(() => {
        const controller = new AbortController();

        apiClient
          .get<Employee[]>("/employees")
          .then((res) => {
            setEmployees(res.data);
            setIsLoading(false);
          })
          .catch((err) => {
            if (err instanceof CanceledError) return;
            setError(err.message);
            setIsLoading(false);
          });


          return () => controller.abort();//what is this
      }, []);
    return { employees, error, isLoading };
}

export default useEmployees;