import React from 'react';

const TaskList = ({ tasks, onEdit, onDelete, onStatusChange }) => {
    const getStatusColor = (status) => {
        switch (status) {
            case 0: return 'bg-gray-200 text-gray-800';
            case 1: return 'bg-blue-200 text-blue-800';
            case 2: return 'bg-blue-200 text-green-800';
            case 3: return 'bg-red-200 text-red-800';
            case 4: return 'bg-gray-200 text-gray-800';
            default: return 'bg-gray-200 text-gray-800';

        }
    };

    const getPriorityColor = (priority) => {
        switch (priority) {
            case 0: return 'text-gray-500';
            case 1: return 'text-yellow-500';
            case 2: return 'text-orange-500';
            case 3: return 'text-red-500';
            default: return 'text-gray-500';
        }
    };

    const getStatusText = (status) => {
        switch (status) {
            case 0: return 'Todo';
            case 1: return 'In Progresss';
            case 2: return 'Completed';
            case 3: return 'Canceled';
            default: return 'Unknown';
        }
    };

    const getPriorityText = (priority) => {
        switch (priority) {
            case 0: return 'Low';
            case 1: return 'Medium';
            case 2: return 'Hight';
            case 3: return 'Urgent';
            default: return 'Unknown';
        }
    };

    if (tasks.length === 0) {
        return (
            <div className="text-center py-12">
                <p className="text-gray-500 text-lg">No tasks yet. Create your first task!</p>
            </div>
        );
    }

    return (
        <div className="space-y-4">
            {tasks.map((task) => (
                <div
                    key={task.id}
                    className="bg-white border border-gray-200 rounded-lg p-6 shadow-sm hover:shadow-md transition"
                >
                    <div className="flex justify-between items-start mb-3">
                        <div className="flex-1">
                            <h3 className="text-xl font-semibold text-gray-800 mb-2">{task.title}</h3>
                            <p className="text-gray-600">{task.description}</p>
                        </div>
                        <div className="flex space-x-2 ml-4">
                            <button
                                onClick={() => onEdit(task)}
                                className="text-blue-600 hover:text-blue-800 font-medium"
                            >
                                Edit
                            </button>
                            <button
                                onClick={() => onDelete(task.id)}
                                className="text-red-600 hover:text-red-800 font-medium"
                            >
                                Delete
                            </button>
                        </div>
                    </div>

                    <div className="flex flex-wrap gap-3 items-center">
                        <span className={`px-3 py-1 rounded-full text-sm font-medium ${getStatusColor(task.status)}`}>
                            {getStatusText(task.status)}
                        </span>
                        <span className={`font-medium ${getPriorityColor(task.priority)}`}>
                            ● {getPriorityText(task.priority)}
                        </span>
                        {task.dueDate && (
                            <span className="text-sm text-gray-500">
                                📅 {new Date(task.dueDate).toLocaleDateString()}
                            </span>
                        )}
                    </div>

                    <div className="mt-4">
                        <label className="text-sm text-gray-600 mr-2">Change Status:</label>
                        <select
                            value={task.status}
                            onChange={(e) => onStatusChange(task.id, parseInt(e.target.value))}
                            className="border border-gray-300 rounded px-3 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                        >
                            <option value={0}>Todo</option>
                            <option value={1}>In Progress</option>
                            <option value={2}>Completed</option>
                            <option value={3}>Cancelled</option>
                        </select>
                    </div>
                </div>
            ))}
        </div>
    );
};

export default TaskList;