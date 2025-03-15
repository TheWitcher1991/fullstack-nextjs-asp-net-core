import { useState } from 'react'

interface UploadsState {
	progress: Nullable<number>
	uploaded: number
	total: number
}

export const useUploadProgress = () => {
	const [uploads, setUploads] = useState<UploadsState>({
		progress: null,
		uploaded: 0,
		total: 0,
	})

	const clearUploads = () => {
		setUploads({
			progress: null,
			uploaded: 0,
			total: 0,
		})
	}

	return {
		uploads,
		setUploads,
		clearUploads,
	}
}
