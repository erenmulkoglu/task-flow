import React, { useState, useEffect } from 'react';
import { useAuth } from '../context/AuthContext';
import { useNavigate } from 'react-router-dom';
import taskService from '../services/taskService';
import TaskList from '../components/Tasks/TaskList';
import TaskForm from '../components/Tasks/TaskForm';

const Dashboard = () => {
    const { user, logout } = useAuth();
    const navigate = useNavigate();
    const [tasks, setTasks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [showForm, setShowForm] = useState(false);
    const [editingTask, setEditingTask] = useState(null);
    const [filter, setFilter] = useState('all');

    useEffect(() => {
        loadTasks();
    }, []);

    const loadTasks = async () => {
        try {
            setLoading(true);
            const data = await taskService.getAllTasks();
            setTasks(data);
        } catch (error) {
            console.error('Error loading tasks:', error);
        } finally {
            setLoading(false);
        }
    };

    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    const handleCreateTask = async (taskData) => {
        try {
            await taskService.createTask(taskData);
            await loadTasks();
            setShowForm(false);
        } catch (error) {
            console.error('Error creating task:', error);
            alert('Failed to create task');
        }
    };

    const handleUpdateTask = async (taskData) => {
        try {
            await taskService.updateTask(editingTask.id, taskData);
            await loadTasks();
            setShowForm(false);
            setEditingTask(null);
        } catch (error) {
            console.error('Error updating task:', error);
            alert('Failed to update task');
        }
    };

    const handleDeleteTask = async (taskId) => {
        if (window.confirm('Are you sure you want to delete this task?')) {
            try {
                await taskService.deleteTask(taskId);
                await loadTasks();
            } catch (error) {
                console.error('Error deleting task:', error);
                alert('Failed to delete task');
            }
        }
    };

    const handleStatusChange = async (taskId, newStatus) => {
        try {
            await taskService.updateTask(taskId, { status: newStatus });
            await loadTasks();
        } catch (error) {
            console.error('Error updating status:', error);
            alert('Failed to update status');
        }
    };

    const handleEdit = (task) => {
        setEditingTask(task);
        setShowForm(true);
    };

    const handleCloseForm = () => {
        setShowForm(false);
        setEditingTask(null);
    };

    const filteredTasks = tasks.filter((task) => {
        if (filter === 'all') return true;
        return task.status === parseInt(filter);
    });

    const stats = {
        total: tasks.length,
        todo: tasks.filter((t) => t.status === 0).length,
        inProgress: tasks.filter((t) => t.status === 1).length,
        completed: tasks.filter((t) => t.status === 2).length,
    };

    if (loading) {
        return (
            <div className="min-h-screen flex items-center justify-center bg-gray-100">
                <div className="text-2xl text-gray-600">Loading...</div>
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-gray-100">
            <nav className="bg-white shadow-lg">
                <div className="max-w-7xl mx-auto px-4 py-4 flex justify-between items-center">
                    <h1 className="text-2xl font-bold text-gray-800">📋 TaskFlow</h1>
                    <div className="flex items-center space-x-4">
                        <span className="text-gray-700">
                            Welcome, <span className="font-semibold">{user?.firstName}!</span>
                        </span>
                        <button
                            onClick={handleLogout}
                            className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600 transition"
                        >
                            Logout
                        </button>
                    </div>
                </div>
            </nav>

            <div className="max-w-7xl mx-auto px-4 py-8">
                <div className="grid grid-cols-1 md:grid-cols-4 gap-6 mb-8">
                    <div className="bg-white rounded-lg shadow p-6">
                        <h3 className="text-lg font-semibold text-gray-700 mb-2">Total Tasks</h3>
                        <p className="text-4xl font-bold text-gray-800">{stats.total}</p>
                    </div>
                    <div className="bg-blue-100 rounded-lg shadow p-6">
                        <h3 className="text-lg font-semibold text-blue-700 mb-2">Todo</h3>
                        <p className="text-4xl font-bold text-blue-600">{stats.todo}</p>
                    </div>
                    <div className="bg-yellow-100 rounded-lg shadow p-6">
                        <h3 className="text-lg font-semibold text-yellow-700 mb-2">In Progress</h3>
                        <p className="text-4xl font-bold text-yellow-600">{stats.inProgress}</p>
                    </div>
                    <div className="bg-green-100 rounded-lg shadow p-6">
                        <h3 className="text-lg font-semibold text-green-700 mb-2">Completed</h3>
                        <p className="text-4xl font-bold text-green-600">{stats.completed}</p>
                    </div>
                </div>

                <div className="bg-white rounded-lg shadow p-6 mb-6">
                    <div className="flex flex-wrap justify-between items-center gap-4">
                        <div className="flex space-x-2">
                            <button
                                onClick={() => setFilter('all')}
                                className={`px-4 py-2 rounded-lg font-medium transition ${filter === 'all'
                                        ? 'bg-blue-600 text-white'
                                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                                    }`}
                            >
                                All
                            </button>
                            <button
                                onClick={() => setFilter('0')}
                                className={`px-4 py-2 rounded-lg font-medium transition ${filter === '0'
                                        ? 'bg-blue-600 text-white'
                                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                                    }`}
                            >
                                Todo
                            </button>
                            <button
                                onClick={() => setFilter('1')}
                                className={`px-4 py-2 rounded-lg font-medium transition ${filter === '1'
                                        ? 'bg-blue-600 text-white'
                                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                                    }`}
                            >
                                In Progress
                            </button>
                            <button
                                onClick={() => setFilter('2')}
                                className={`px-4 py-2 rounded-lg font-medium transition ${filter === '2'
                                        ? 'bg-blue-600 text-white'
                                        : 'bg-gray-200 text-gray-700 hover:bg-gray-300'
                                    }`}
                            >
                                Completed
                            </button>
                        </div>
                        <button
                            onClick={() => setShowForm(true)}
                            className="bg-green-600 text-white px-6 py-2 rounded-lg font-semibold hover:bg-green-700 transition"
                        >
                            + New Task
                        </button>
                    </div>
                </div>

                <TaskList
                    tasks={filteredTasks}
                    onEdit={handleEdit}
                    onDelete={handleDeleteTask}
                    onStatusChange={handleStatusChange}
                />
            </div>

            {showForm && (
                <TaskForm
                    task={editingTask}
                    onSubmit={editingTask ? handleUpdateTask : handleCreateTask}
                    onCancel={handleCloseForm}
                />
            )}
        </div>
    );
};

export default Dashboard;