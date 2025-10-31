import { Button, HStack, List, ListItem, Spinner } from "@chakra-ui/react";

import type { Department } from "../hooks/useDepartments";
import useDepartments from "../hooks/useDepartments";

interface Props {
  onSelectDepartment: (department: Department) => void;
  selectedDepartment: Department | null;

}

const DepartmentList = ({ onSelectDepartment, selectedDepartment }: Props) => {
  const { data: departments, error, isLoading } = useDepartments();
  if (error) return null;

  if (isLoading) return <Spinner />;
  return (
    
      <List>
        {departments.map((department) => (
          
          <ListItem key={department.id} paddingY="5px">
            <HStack>
              <Button
                onClick={() => onSelectDepartment(department)}
                variant="link"
              
                fontSize="lg"
                colorScheme={department.id === selectedDepartment?.id ? "yellow" : "white"}
              >
                {department.name}
              </Button>
            </HStack>
          </ListItem>
        ))}
      </List>
    
  );
};
export default DepartmentList;
