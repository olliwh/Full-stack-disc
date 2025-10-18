import React from "react";
import apiClient from "../services/api-client";
import { Text } from "@chakra-ui/react";
interface Employee {
  id: number;
  name: string;
}
interface EmployeeResponse {
  count: number;
  results: Employee[];
}
const EmployeeGrid = () => {
  const [employees, setEmployees] = React.useState<Employee[]>([]);

  const [error, setError] = React.useState("");
  React.useEffect(() => {
    apiClient
      .get<EmployeeResponse>("/employees")
      .then((res) => setEmployees(res.data.results))
      .catch((err) => setError(err.message));
  }, []);
  return (
    <div>
      {error && <Text color="tomato">{error}</Text>}
      <ul>
        {employees.map((employee) => (
          <li key={employee.id}>{employee.name}</li>
        ))}
      </ul>
    </div>
  );
};
export default EmployeeGrid;
