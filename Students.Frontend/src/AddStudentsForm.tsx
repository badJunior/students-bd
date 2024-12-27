import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useState } from "react"

function AddStudentsForm() {
    const [newStudentName, setNewStuedentName] = useState<string | null>()
    const queryClient = useQueryClient();
    const addMutation = useMutation({
        mutationFn: () =>
            fetch("http://localhost:5242/students", {
                method: "POST",
                body: JSON.stringify({ newStudentName }),
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                },
            }
            ),

        onSuccess: () => {
            // Invalidate and refetch
            queryClient.invalidateQueries({ queryKey: ["students"], exact: false });

        },
    });
    return (
        <div className="grid grid-rows-2 gap-1 h-auto w-full">
            <div className="size-full">
                <input type="text" defaultValue={newStudentName ?? ""} className="w-full" onChange={(e) => {
                    setNewStuedentName(e.target.value)
                }}
                />
            </div>

            <button
                disabled={newStudentName == null || newStudentName == ""}
                onClick={() => addMutation.mutate()}
                className="disabled:bg-slate-400 p-1 bg-slate-600 rounded-lg hover:bg-slate-800 active:bg-slate-900 h-9">
                add student
            </button>

        </div>

    )
}
export default AddStudentsForm