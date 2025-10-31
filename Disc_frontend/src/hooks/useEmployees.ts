import useData from "./useData";
import type { Department } from "./useDepartments";

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

const useEmployees = (selectedDepartment: Department | null) =>
  useData<Employee>(
    "/employees",
    { params: { departments: selectedDepartment?.id } },
    [selectedDepartment?.id],
  );
export default useEmployees;
