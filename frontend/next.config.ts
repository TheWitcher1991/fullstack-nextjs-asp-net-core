import type { NextConfig } from 'next'

const nextConfig: NextConfig = {
	compress: true,
	reactStrictMode: true,
	swcMinify: true,
	generateEtags: true,
	poweredByHeader: false,
	productionBrowserSourceMaps: false,
	crossOrigin: 'use-credentials',
	typescript: {
		ignoreBuildErrors: true,
	},
	eslint: {
		ignoreDuringBuilds: true,
	},
	images: {
		remotePatterns: [],
	},
	async rewrites() {
		return [
			{
				source: '/api/:path*',
				destination: 'https://localhost:8000/api/:path*',
			},
		]
	},
}

export default nextConfig
