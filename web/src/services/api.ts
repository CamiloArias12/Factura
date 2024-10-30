
export async function apiGet<T>(
  path: string,
): Promise<T | null> {
  try {
    const response = await fetch(`${import.meta.env.VITE_API_URL}${path}`);
    return await response.json();
  } catch (e) {
    console.error(e);
    return null;
  }
}
