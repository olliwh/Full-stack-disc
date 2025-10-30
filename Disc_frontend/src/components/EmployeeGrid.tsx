import { SimpleGrid, Text } from "@chakra-ui/react";
import { type Employee } from "../hooks/useEmployees";
import EmployeeCard from "./EmployeeCard";
import EmployeeCardSkeleton from "./EmployeeCardSkeleton";
import useData from "../hooks/useData";

const EmployeeGrid = () => {
    const {
    data: employees,
    error,
    isLoading,
  } = useData<Employee>("/employees");
  // const skeletons = [...Array(employees.length).keys()];
  const skeletons = [...Array(10).keys()];
  


  return (
    <div>
      {error && <Text color="tomato">{error}</Text>}
      {isLoading && <Text>Loading...{isLoading}</Text>}
      <SimpleGrid
        columns={{ sm: 1, md: 2, lg: 3, xl: 5 }}
        spacing={10} //space between cards
        padding="10" //space to sides
      >
        {isLoading &&
          skeletons.map((skeleton) => <EmployeeCardSkeleton key={skeleton} />)}

        {employees?.map((employee) => (
          <EmployeeCard employee={employee} key={employee.id} />
        ))}
      </SimpleGrid>
    </div>
  );
};
export default EmployeeGrid;
