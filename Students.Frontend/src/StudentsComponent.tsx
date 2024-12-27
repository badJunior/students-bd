import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

type Student = { name: string, id: number }

function StudentsComponent() {

    const { isPending, data } = useQuery<Student[]>({
        queryKey: ["students"],
        queryFn: () =>
            fetch("http://localhost:5242/students").then((res) => res.json()),
    })

    const queryClient = useQueryClient();

    const deleteMutation = useMutation({
        mutationFn: (id: number) =>
            fetch(`http://localhost:5242/students/${id}`, {
                method: "DELETE",
            }
            ),
        onSuccess: () => {
            // Invalidate and refetch
            queryClient.invalidateQueries({ queryKey: ["students"], exact: false });

        },
    });

    if (isPending) { return (<span> Loading...</span>) }
    if (data == null) { return (<span> Error </span>) }

    return (
        <StudentsList students={data} onDeleteClick={(id) => deleteMutation.mutate(id)} />
    )
}

function StudentsList(props: { students: Student[], onDeleteClick: (id: number) => void }) {
    return (<ul className="bg-slate-600 p-1 rounded-lg size-full ">
        {props.students.map(student => (
            <li className="hover:bg-slate-700">
                <div className="flex w-full">
                    <span className="size-full">
                        {student.name}
                    </span>
                    <button
                        onClick={() => props.onDeleteClick(student.id)}
                        className="aspect-square bg-slate-600 p-1 rounded-lg hover:bg-slate-800 active:bg-slate-900 size-9">
                        X
                    </button>
                </div>

            </li>))}
    </ul>)
}
export default StudentsComponent